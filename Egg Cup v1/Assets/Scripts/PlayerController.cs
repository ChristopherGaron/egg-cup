using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // START() VARIABLES
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    // FINITE STATE MACHINE
    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;


    // CALLING GROUND COLLISION
    [SerializeField] private LayerMask ground;
    
    // STATS CONTROLLER
    [SerializeField] private float speed = 7.5f;
    [SerializeField] private float jumpHeight = 7.5f;


    // HEIGHT COUNTER - UNUSED
    [SerializeField] private Text heightText;

    // ENEMY KNOCKBACK
    [SerializeField] private float knockBack = 10f;


    // CREATING VARIABLES
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(state == State.falling)
            {
                Destroy(other.gameObject);
            }
            else 
            {
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    // ENEMY ON THE RIGHT AND KNOCKBACKS LEFT
                    rb.velocity = new Vector2(-knockBack, rb.velocity.y);
                    state = State.hurt;
                }
                else
                {
                    // ENEMY ON THE LEFT AND KNOCKBACKS RIGHT
                    rb.velocity = new Vector2(knockBack, rb.velocity.y);
                    state = State.hurt;
                }
            }
            
        }
    }

    // ---------------------------------------------------------------------------


    // MOVEMENT 
    private void Update()
    {

        float hDirection = Input.GetAxis("Horizontal");

        // MOVING LEFT + FLIPPING SPRITE
        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        // MOVING RIGHT + FLIPPING SPRITE
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        // JUMPING + STATE TRANSFORM

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            state = State.jumping;
        }

        VelocityState();
        anim.SetInteger("state", (int)state);

        // STOPPING ON THE GROUND

        if (Input.GetButtonDown("Vertical") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }


    // STATE CYCLER FOR JUMP/FALL/IDLE
    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if(Mathf.Abs(rb.velocity.x) > 2f) 
        {
            //Moving
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
  
    }
}
