using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : EnemyMovement {

	// Use this for initialization
	void Awake () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void OnCollisionEnter(Collision collision)
    {
        SwitchDirection(collision.transform.tag);
    }

    public override void OnStomp()
    {
        Debug.Log("100");
        Destroy(gameObject);
    }
}
