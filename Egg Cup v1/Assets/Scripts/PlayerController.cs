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
    private enum State {idle, running, jumping, falling, hurt, sliding}
    private State state = State.idle;


    // CALLING GROUND COLLISION
    [SerializeField] private LayerMask ground;
    
    // STATS CONTROLLER
    [SerializeField] private float speed = 7.5f;
    [SerializeField] private float slowWalkSpeed = 3.5f;
    [SerializeField] private float jumpHeight = 7.5f;


    // HEIGHT COUNTER - UNUSED
    [SerializeField] private Text heightText;

    // ENEMY KNOCKBACK
    [SerializeField] private float knockBack = 10f;

    // BUTTON INPUTS
    private bool leftDown, rightDown, downDown, jumpDown, shiftDown;

    public bool hasEgg;

    public bool onGround;
    public float coyoteTime;
    private float coyoteCount;
    private float jumpLag;

    public bool freezeInput;

    // JUMP SOUND
    AudioSource jumpSound;


    // CREATING VARIABLES
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
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

    private void GetInputs()
    {
        if (!freezeInput)
        {
            leftDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0;
            rightDown = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0;
            downDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0;
            jumpDown = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
            shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        }
    }

    // MOVEMENT 
    private void Update()
    {
        GetInputs();

        var velo = rb.velocity;

        // MOVING LEFT + FLIPPING SPRITE
        if(leftDown)
        {
            velo.x = !shiftDown ? -slowWalkSpeed : -speed;
            transform.localScale = new Vector2(-1, 1);
        }
        // MOVING RIGHT + FLIPPING SPRITE
        else if (rightDown)
        {
            velo.x = !shiftDown ? slowWalkSpeed : speed;
            transform.localScale = new Vector2(1, 1);
        }
        // STOPPING ON GROUND
        else if (downDown && coll.IsTouchingLayers(ground))
        {
            //Patching DuccTech
            //velo = new Vector2(0f, 0f);
            velo = new Vector2(0f, rb.velocity.y);
        }

        if(coll.IsTouchingLayers(ground))
        {
            onGround = true;
            coyoteCount = 0;
        }
        else
        {
            if(coyoteCount > coyoteTime)
            {
                onGround = false;
            }
            coyoteCount += Time.deltaTime;
        }

        jumpLag -= Time.deltaTime;
        // JUMPING + STATE TRANSFORM
        if (jumpDown && onGround && jumpLag < 0)
        {
            jumpSound.Play();
            velo = new Vector2(rb.velocity.x, jumpHeight);
            state = State.jumping;
            jumpLag = 0.25f;
        }

        rb.velocity = velo;

        VelocityState();
        anim.SetInteger("state", (int)state);
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
        else if(Input.GetAxisRaw("Horizontal") != 0 && !freezeInput) 
        {
            //Moving
            state = State.running;
        }
        else if(Input.GetAxisRaw("Horizontal") == 0 && rb.velocity.x != 0 && !freezeInput)
        {
            //sliding
            //state = State.sliding;
            state = State.idle;
        }
        else
        {
            state = State.idle;
        }
  
    }
}
