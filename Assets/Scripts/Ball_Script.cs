using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Script : MonoBehaviour {

	private ParticleSystem GoalSystem;


	void Awake() {
		GoalSystem = GetComponent<ParticleSystem> ();
	}

	void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("grabbable")) {
            Debug.Log(col.tag + "farts");
            GoalSystem.Play ();
		}


    }
    
}

	
