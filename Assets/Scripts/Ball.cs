using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;

public class Ball : MonoBehaviour, ICollisionEnter
{

    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

    public Rigidbody rigidbody;

    private bool _isScoredByThisBall = false;
    private bool _isBallKicked = false;


    private void Update()
    {
        if (_isBallKicked)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            float distance = Vector3.Distance(startPos, endPos);
            float swipeVelocity = distance / (timeInterval * 1000); // Time interval is in milisecond. so convert it into seconds
           // Debug.Log("U>> D - " + distance + " time " + timeInterval + "  swipeVelocity " + swipeVelocity);

            if ( distance < 100)
                return;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;
            direction = direction.normalized;


            // add force to balls rigidbody in 3D space depending on swipe time and direction
            // first calculate the swipe x direction. Y and Z force would be based on swipe speed.
            // I found 200, 20 and 50 is good for this game. 
            Vector3 force = new Vector3(-direction.x * 50, swipeVelocity * 20f, swipeVelocity * 50);
           // Debug.Log("U>> direction " + direction + " force  " + force);
            rigidbody.AddForce(force);
      

            GameManager.shared.GetGameInstances().soundManager.PlayKickSound();
            _isBallKicked = true;
            StartCoroutine(OnKickCompleteAction(3.0f,0));
        }
    }

  

    IEnumerator OnKickCompleteAction(float time, int score = 0)
    {
        yield return new WaitForSeconds(time);

        GameManager.shared.OnBallKicked(score);
        Destroy(gameObject);
    }

    public void onCollisionEnter(GameObject collidedObj)
    {
        if (_isScoredByThisBall)
            return;

        IScore scoreItem = collidedObj.GetComponent<IScore>();

        if (scoreItem != null)
        {
            _isScoredByThisBall = true;
            StopAllCoroutines();
            StartCoroutine(OnKickCompleteAction(3, scoreItem.GetPoint()));
            //In net ball should be slower .so reduce its speed 
            rigidbody.velocity = rigidbody.velocity / 3;
        }
        this.gameObject.layer = LayerMask.NameToLayer("Default");
        //Debug.Log("U>> Yahoo goallll  " + collidedObj.gameObject.name);
        IReacatble reactable = collidedObj.GetComponent<IReacatble>();
        reactable?.ReactOnCollide();

    }
}
