using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Script : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D trig) {
		if(trig.gameObject.tag == "goal") {
			Debug.Log("Touched Goal");
		}

	}

}

	
