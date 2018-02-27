using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D trig) {
		if(trig.gameObject.tag == "goal") {
			Debug.Log("Touched Goal");
		}

	}

}

	
