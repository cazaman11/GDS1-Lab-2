using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBorderScript : MonoBehaviour {
    Collider thisCollider;
    Rigidbody thisRigidbody;
    [SerializeField]
    bool left;
	// Use this for initialization
	void Start () {
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Mario" && left)
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.name != "Mario" && !left)
        {
            collision.gameObject.SetActive(true);
        }
        if (collision.gameObject.name == "Mario")
        {
            //thisRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Mario")
        {
            /*
            thisRigidbody.constraints = RigidbodyConstraints.None;
            thisRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            thisRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            thisRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            */

        }
    }
}
