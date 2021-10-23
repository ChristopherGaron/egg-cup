using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public GameObject JumpPad;
    private Rigidbody2D jprb;
    public Transform FiredPosition, RestPosition;

    //the speed at which the platform rises, how long it stays, and then how long it takes to reset.
    public float ToFiredTime, StayTime, ToRestTime;
    private float ToFiredCount, StayCount, ToRestCount;

    public float CycleTime;
    private float CycleCount;

    //whether or not the Jump Pad can be fired.
    public bool Primed;

    private Vector2 moveDirection;
    private float moveDistance;

    public bool NoAutoPrime;

    // Start is called before the first frame update
    void Start()
    {
        jprb = JumpPad.GetComponent<Rigidbody2D>();

        moveDirection = ((Vector2)FiredPosition.position - (Vector2)RestPosition.position).normalized;
        moveDistance = ((Vector2)FiredPosition.position - (Vector2)RestPosition.position).magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the platform along the "track" between RestPosition and FiredPosition based on the count of time left to reach the target position.
        //You can manipulate the JumpPad by adjusting the positions and how much time it takes to reach each position.
        if(!Primed)
        {
            if(ToFiredCount > 0)
            {
                jprb.MovePosition((Vector2)RestPosition.position + (moveDirection * (moveDistance * (1 - ToFiredCount / ToFiredTime))));
                ToFiredCount -= Time.fixedDeltaTime;
            }
            else if(StayCount > 0)
            {
                jprb.MovePosition(FiredPosition.position);
                StayCount -= Time.fixedDeltaTime;
            }
            else if (ToRestCount > 0)
            {
                jprb.MovePosition((Vector2)RestPosition.position + (moveDirection * (moveDistance * (ToRestCount / ToRestTime))));
                ToRestCount -= Time.fixedDeltaTime;
            }
            else if(!NoAutoPrime)
            {
                Primed = true;
                JumpPad.transform.position = RestPosition.position;
            }
        }
        else
        {
            if(CycleTime > 0)
            {
                if(CycleCount <= 0)
                {
                    FireJumpPad();
                }

                CycleCount -= Time.fixedDeltaTime;
            }
        }
    }

    public void FireJumpPad()
    {
        //if the Jump Pad is Primed, Fire it by resetting the counts
        if (Primed)
        {
            Primed = false;
            ToFiredCount = ToFiredTime;
            StayCount = StayTime;
            ToRestCount = ToRestTime;
            CycleCount = CycleTime;
        }
    }

    void OnDrawGizmos()
    {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(RestPosition.position, FiredPosition.position);
    }
}
