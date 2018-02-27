using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private Player_Health player;

	void Start() {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Health> ();

	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("Player")){

			player.Damage (1);

//			StartCoroutine (player.Knockback (0.2f, 50, player.transform.position));

		}

	}

}
