//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour {

//	//how fast the player can move
//	public float topSpeed = 10f;
//	//tell the sprite which direction it is facing
//	bool facingRight = true;
//	//get reference to animator
//	Animator anim;
//	//not grounded
//	bool grounded = false;
//	//transform at players foot to see if he is touching the ground
//	public Transform groundCheck;
//	//how big the circle is going to be when we check distance to the ground
//	public float groundRadius = 0.2f;
//	// force of jump
//	public float jumpForce = 700f;
//	//what layer is the ground
//	public LayerMask whatIsGround;
//	//variable to check double jump
//	public bool doubleJump;
//    public GameObject forceField;



//    void Start() {
//		anim = GetComponent<Animator> ();
//	}


//	void FixedUpdate() {

//		//true or false did the ground transform hit the whatIsGround with the groundRadius
//		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

//		//get direction
//		float move = Input.GetAxis("Horizontal");

//		//tell the animator we are grounded
//		anim.SetBool ("Ground", grounded);

//		//get how fast we are moving up or down from the rigidbody
//		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);


//		//add velocity to the rigidbody in the move direction * our speed
//		GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

//		anim.SetFloat("Speed", Mathf.Abs (move));

//		//if we're facing the negative direction and not facing right, flip
//		if (move > 0 && !facingRight)
//			Flip ();
//		else if (move < 0 && facingRight)
//			Flip ();
//	}

//	void Update()
//    {
//		if (Input.GetButtonDown ("Jump"))
//        {
//			if(grounded)
//            {
//				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
//				doubleJump = true;
//			} else {
//				if(doubleJump)
//                {
//					doubleJump = false;
//					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, 0);
//					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);

//				}
//			}
//		}

//        Physics2D.IgnoreCollision(forceField.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
//        Physics2D.IgnoreCollision(forceField.GetComponent<Collider2D>(), GetComponent<CircleCollider2D>());

//    }

//	void Flip() {

//		//saying we are facing the opposite direction
//		facingRight = !facingRight;

//		//get the local scale
//		Vector3 theScale = transform.localScale;

//		//flip on the x axis
//		theScale.x *= -1;

//		//apply that to the local scale
//		transform.localScale = theScale;
//	}
//}
