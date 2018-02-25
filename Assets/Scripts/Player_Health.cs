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

	public void Damage(int dmg){

		curHealth -= dmg;

	}

//	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
//
//		float timer = 0;
//		while(knockDur > timer) {
//
//			timer += Time.deltaTime;
//
//			GetComponent<Rigidbody2D> ().AddForce (new Vector3 (knockbackDir.x * -10, knockbackDir.y + knockbackPwr, transform.position.z));
//
//		}
//
//		yield return 0;
//
//	}

    void Die ()
    {
		SceneManager.LoadScene("Proto_Platformer");
    }
}
