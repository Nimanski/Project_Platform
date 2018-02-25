using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Image HeartUI;

	private Player_Health player;


	void Start() {
		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player_Health> ();
	}

	void Update() {

		HeartUI.sprite = HeartSprites[player.curHealth];

	}
}
