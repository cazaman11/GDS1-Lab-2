using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour {

    private bool goLeft;
    [SerializeField]
    private float speed;

	// Use this for initialization
	void Awake () {
        goLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (goLeft)
        {
            transform.position += Vector3.left * speed;
        }
        else {
            transform.position += Vector3.right * speed;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Floor") {
            goLeft = !goLeft;
        }
    }
}
