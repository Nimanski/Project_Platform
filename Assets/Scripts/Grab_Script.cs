using UnityEngine;

public class Grab_Script : MonoBehaviour
{
    #region Properties
    public bool grabbed;
	Collider2D hit;
    public float distance=2f;
	public float throwForce;
	public Transform holdPoint;
    public float reachRadius = 1f;
    public LayerMask ballMask;
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Grab"))
        {
            GrabObject();
		}

        if (Input.GetButtonUp("Grab") && grabbed)
        {
            ThrowObject();
        }

		if (grabbed)
        {
			hit.gameObject.transform.position = holdPoint.position;
		}
	}

	void OnDrawGizmos() {
		//Gizmos.color = Color.green;
		//Gizmos.DrawLine (rayPoint.position, rayPoint.position + Vector3.right * rayPoint.localScale.x * distance);
    }

    private void GrabObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, reachRadius, ballMask);

        foreach(var collider in colliders)
        {
            if (collider != null && collider.tag == "grabbable")
            {
                grabbed = true;
                hit = collider;
                hit.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
            }
        }
    }

    private void ThrowObject()
    {
        grabbed = false;
		hit.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;

        if (hit.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            var throwX = transform.localScale.x;
            var throwY = Input.GetAxis("Vertical");
            Debug.Log("throwY: " + throwY);
            hit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(throwX, throwY) * throwForce;
        }
    }
}
