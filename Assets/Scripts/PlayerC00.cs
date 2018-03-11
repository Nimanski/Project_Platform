//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent (typeof (Controller2D))]
//public class PlayerC : MonoBehaviour {

//    public float jumpHeight = 4;
//    public float timeToJumpApex = .4f;
//    float moveSpeed = 6;
//    public float accelerationTimeAirborne = .2f;
//    public float accelerationTimeGrounded = .1f;
//    float velocityXSmoothing;

//    public float gravity;
//    public float jumpVelocity;
//    Vector3 velocity;

//    Controller2D controller;
        
//	void Start () {
//        controller = GetComponent<Controller2D> ();

//        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
//        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
//        print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
//	}

//    void Update()
//    {
//        if(controller.collisions.above || controller.collisions.below)
//        {
//            velocity.y = 0;
//        }

//        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

//        if (Input.GetButtonDown("Jump") && controller.collisions.below)
//        {
//            velocity.y = jumpVelocity;
//        }

//        float targetVelocityX = input.x * moveSpeed;
//        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
//        velocity.y += gravity * Time.deltaTime;
//        controller.Move(velocity * Time.deltaTime);
//    }
//}
