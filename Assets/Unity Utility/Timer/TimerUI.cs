using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour,Timer.Delegate
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button pauseButton;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button resetButton;

	[SerializeField] private Text timeText;
	[SerializeField] private Text completedMessageText;

    [SerializeField] private InputField _inputField;

	[SerializeField] Timer _timer;


	private void Start()
	{
		HideAllUI();
		startButton.interactable = true;
		_timer.SetDelegate(this);
	}

	private void Update()
	{
		if(_timer.IsTimeSet() == true && _timer.GetIsTimerRunning() == true)
		{
			float elapsedTime = _timer.GetElapsedTime();
			float remainingTime = (GetInputSecond() * 1.0f) - elapsedTime;
			
			timeText.text = Mathf.Floor( remainingTime) + "";
		}
		
	}

	private int GetInputSecond()
	{
		int second = 0;
		if(_inputField != null)
		{
			second = Convert.ToInt32(_inputField.text);
		}
		return second;
	}
	public void OnClickStartButton()
	{
		HideAllUI();
		pauseButton.interactable = true;
		resetButton.interactable = true;

		_timer.StartTimer(GetInputSecond());

	}
	public void OnClickPauseButton()
	{
		HideAllUI();
		resumeButton.interactable = true;
		resetButton.interactable = true;

		_timer.PauseTimer();
	}
	public void OnClickResumeButton()
	{
		HideAllUI();
		pauseButton.interactable = true;
		resetButton.interactable = true;

		_timer.ResumeTimer();
	}
	public void OnClickResetButton()
	{
		HideAllUI();
		pauseButton.interactable = true;
		resetButton.interactable = true;

		_timer.StartTimer(GetInputSecond());
	}

	void HideAllUI()
	{
		startButton.interactable = false;
		pauseButton.interactable = false;
		resumeButton.interactable = false;
		resetButton.interactable = false;

		completedMessageText.enabled = false;
	}

	
    public void OnTimeComplete()
    {
		_timer.PauseTimer();
		HideAllUI();

		startButton.interactable = true;
		resetButton.interactable = true;

		completedMessageText.enabled = true;

	}
}
