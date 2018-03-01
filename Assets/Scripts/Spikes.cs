using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private Player_Health player;

	void Start() {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Health> ();

	}

	void OnCollisionEnter2D(Collision2D col) {

		if(col.transform.CompareTag("Player")){

			player.Damage (1);


//			StartCoroutine (player.Knockback (0.2f, 50, player.transform.position));

		}

	}

}
