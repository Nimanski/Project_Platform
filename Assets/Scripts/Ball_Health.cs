using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Health : MonoBehaviour {

    public int curBHealth;
    public int maxBHealth = 1;
    public bool hasBDied;

    // Use this for initialization
    void Start()
    {
        hasBDied = false;
        curBHealth = maxBHealth;
    }

    void Update()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.y < -7)
        {
            ballDie();
        }
        if (curBHealth > maxBHealth)
        {
            curBHealth = maxBHealth;
        }
        if (curBHealth < 0)
        {
            curBHealth = 0;
        }

        if (curBHealth <= 0)
        {
            ballDie();
        }
    }

    public void BDamage(int dmg)
    {

        curBHealth -= dmg;

    }


    void ballDie()
    {
        SceneManager.LoadScene("Proto_Platformer");
    }
}
