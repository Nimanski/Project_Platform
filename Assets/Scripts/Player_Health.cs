using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public int curHealth;
	public int maxHealth = 3;
    public bool hasDied;

	// Use this for initialization
	void Start ()
    {
        hasDied = false;
		curHealth = maxHealth;
	}

	void Update()
	{


	}

    // Update is called once per frame
    void FixedUpdate()
	{
		if (gameObject.transform.position.y < -7) {
			Die ();
		}
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {
			Die ();
		}
	}

    void Die ()
    {
		SceneManager.LoadScene("Proto_Platformer");
    }
}
