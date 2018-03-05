using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Improved : MonoBehaviour {

    public float reachRadius = 2f;
    public LayerMask ballMask;
    //    RaycastHit2D[] objectNear;
    //Collider2D[] c;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, reachRadius, ballMask);

        if (colliders.Length > 0) {
            Debug.Log("Can Grab!");
        }

        //objectNear = Physics2D.CircleCastAll(transform.position, reachRadius, Vector3.forward);

        //foreach (var obj in objectNear)
        //{
        //    if(obj.collider.tag == "grabbable")
        //    {
        //        Debug.Log("Can Grab!");
        //    }
        //}
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
