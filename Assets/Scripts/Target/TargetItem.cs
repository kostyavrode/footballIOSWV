using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TargetItem : MonoBehaviour, IScore,IReacatble
{

    [SerializeField] private TMP_Text pointText;
   
    [SerializeField]public int time = 5;


    private bool _isItCollidedByBall = false;
    private Sequence sequence;
    private Vector3 initialPos;
    private Rigidbody _rb;
    private int _point = 1;
    private MeshRenderer _meshRenderer;
    private Collider _collider;
    private Canvas _canvas;


    private enum MOVE_DIRECTION
    {
        None,
        X,
        Y,
        Z
    }

    //[SerializeField] private bool isMoveable = false;
    [SerializeField] private MOVE_DIRECTION moveDirection = MOVE_DIRECTION.None;
    [SerializeField] private float destinationValue;

    DataManager _dataManager;

    private void Awake()
    {
        _dataManager = new DataManager(new LocalDataFetcher());
        initialPos = transform.localPosition;
       // Debug.Log("Awake  " + initialPos);
        _rb = gameObject.GetComponent<Rigidbody>();
        _collider = gameObject.GetComponent<Collider>();
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        _canvas = gameObject.GetComponentInChildren<Canvas>();
    }

    public int GetPoint()
    {
        return _point;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ReactOnCollide();
        }
    }

    public void SetPoint(int point)
    {
        _point = point;
        pointText.text = _point + "";
    }


    private IEnumerator DisableItem(float time)
    {
        yield return new WaitForSeconds(time);
       

        SetPoint(0);
        sequence?.Kill();

        _meshRenderer.enabled = false;
        _collider.enabled = false;
        _canvas.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        ResetItem();
    }

    private void OnDisable()
    {
        sequence?.Kill();
    }

    public void ResetItem()
    {

        SetPoint(_dataManager.GetTargetValue_notMoveable());
        _isItCollidedByBall = false;

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        transform.localPosition = initialPos;
        transform.localRotation = Quaternion.Euler(0, 0, 0);


        _meshRenderer.enabled = true;
        _collider.enabled = true;
        _canvas.gameObject.SetActive(true);

        if (moveDirection != MOVE_DIRECTION.None)
        {
            SetPoint(Random.Range(_dataManager.GetMinTargetValue_moveable(),
                                _dataManager.GetMaxTargetValue_moveable()));
            StartCoroutine(StartMovement());
        }
    }


    private IEnumerator StartMovement()
    {

        yield return new WaitForSeconds(1.0f);
        sequence = DOTween.Sequence();

        switch (moveDirection)
        {
            case MOVE_DIRECTION.X:
                sequence.Append(transform.DOLocalMoveX(destinationValue, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
                break;
            case MOVE_DIRECTION.Y:
                sequence.Append(transform.DOLocalMoveY(destinationValue, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
                break;

            case MOVE_DIRECTION.Z:
                sequence.Append(transform.DOLocalMoveZ(destinationValue, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
                break;
        }  
    }

   

    public void ReactOnCollide()
    {
        _isItCollidedByBall = true;
        sequence?.Kill();
        GameManager.shared.GetGameInstances().soundManager.PlayTargetCollideSound();
        StartCoroutine(DisableItem(1.0f));

        GameManager.shared.GetGameInstances().soundManager.PlayCelebrationSound();
        GameObject particleObj = Instantiate(GameManager.shared.GetGameInstances().particle_goalText);
        particleObj.transform.position = new Vector3(0, 5, 0);
        Destroy(particleObj, 3.0f);

    }
}


// ALl object which will react externally (like explode/sound) with collision will implement this.
public interface IReacatble
{
    void ReactOnCollide();
}
