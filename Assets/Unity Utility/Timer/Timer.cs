using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;

    private float _startTime;
    private bool _isTimerOn = false;
    private float _pauseStartTime;
    private float _pauseTimeOfCurrentSession;
    private float _totalPauseTime;

    private bool _isTimeSet = false;
    private Delegate _delegate;

    #region Public APi

    public void SetDelegate(Delegate timeDelegate)
    {
        this._delegate = timeDelegate;
    }

    public void StartTimer(float time)
    {
        _isTimeSet = true;
        ResetTimer();
        this._time = time;
        _isTimerOn = true;
    }

    public void PauseTimer()
    {
        _isTimerOn = false;
        _pauseStartTime = Time.time;
    }

    public void ResumeTimer()
    {
        _isTimerOn = true;
        _totalPauseTime = _totalPauseTime + _pauseTimeOfCurrentSession;
        _pauseTimeOfCurrentSession = 0.0f;
    }

    public bool IsTimeSet()
    {
        return _isTimeSet;
    }
    public bool GetIsTimerRunning()
    {
        return _isTimerOn;
    }
	public float GetElapsedTime()
	{
		return Mathf.Abs(Time.time - _startTime - _pauseTimeOfCurrentSession - _totalPauseTime);
	}
	#endregion Public APi

	private void ResetTimer()
    {
        _startTime = Time.time;
        _pauseTimeOfCurrentSession = 0.0f;
        _totalPauseTime = 0.0f;
    }

    private void Update()
    {
        if(_isTimerOn == false)
        {
            _pauseTimeOfCurrentSession = Time.time - _pauseStartTime;
        }
        if ( GetElapsedTime() > _time && _isTimerOn == true)
        {
            OnTimerComplete();
        }
    }
    
    private void OnTimerComplete()
    {
        if (this._delegate != null)
            this._delegate.OnTimeComplete();

        ResetTimer();
    }


    public interface Delegate
    {
        void OnTimeComplete();
    }

}
