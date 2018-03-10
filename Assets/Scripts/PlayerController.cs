using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //grab
    public bool grabbed;
    Collider2D hit;
    public float distance = 2f;
    public float throwForce;
    public Transform holdPoint;
    public float reachRadius = 1f;
    public LayerMask ballMask;

    //how fast the player can move
    public float topSpeed = 10f;
	//tell the sprite which direction it is facing
	bool facingRight = true;
	//get reference to animator
	Animator anim;
	//not grounded
	bool grounded = false;
	//transform at players foot to see if he is touching the ground
	public Transform groundCheck;
	//how big the circle is going to be when we check distance to the ground
	public float groundRadius = 0.2f;
	// force of jump
	public float jumpForce = 700f;
	//what layer is the ground
	public LayerMask whatIsGround;
	//variable to check double jump
	public bool doubleJump;

    //BetterJump
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate() {

		//true or false did the ground transform hit the whatIsGround with the groundRadius
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		//get direction
		float move = Input.GetAxis("Horizontal");

		//tell the animator we are grounded
		anim.SetBool ("Ground", grounded);

		//get how fast we are moving up or down from the rigidbody
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
        
		//add velocity to the rigidbody in the move direction * our speed
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

		anim.SetFloat("Speed", Mathf.Abs (move));

		//if we're facing the negative direction and not facing right, flip
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

        //BetterJump
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }


	void Update() {
		if (Input.GetButtonDown ("Jump"))
        {
			if(grounded) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				doubleJump = true;
			} else {
				if(doubleJump) {
					doubleJump = false;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, 0);
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);

				}
			}
		}
        if (Input.GetButtonDown("Grab"))
        {
            GrabObject();
        }

        if (Input.GetButtonUp("Grab") && grabbed)
        {
            ThrowObject();
        }

        if (grabbed)
        {
            hit.gameObject.transform.position = holdPoint.position;
        }
    }

    private void GrabObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, reachRadius, ballMask);

        foreach (var collider in colliders)
        {
            if (collider != null && collider.tag == "grabbable")
            {
                grabbed = true;
                hit = collider;
                hit.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
        }
    }

    private void ThrowObject()
    {
        grabbed = false;
        hit.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;

        if (hit.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            var throwX = transform.localScale.x;
            var throwY = Input.GetAxis("Vertical");
            Debug.Log("throwY: " + throwY);
            hit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(throwX, throwY) * throwForce;
        }
    }

    void Flip() {

		//saying we are facing the opposite direction
		facingRight = !facingRight;

		//get the local scale
		Vector3 theScale = transform.localScale;

		//flip on the x axis
		theScale.x *= -1;

		//apply that to the local scale
		transform.localScale = theScale;
	}
}
