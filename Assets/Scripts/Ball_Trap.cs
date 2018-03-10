using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Trap : MonoBehaviour {

    private Ball_Health ball;

    void Start()
    {

        ball = GameObject.FindGameObjectWithTag("grabbable").GetComponent<Ball_Health>();

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.transform.CompareTag("grabbable"))
        {

            ball.BDamage(1);

        }

    }
}
