using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : NPCMovement {

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
        SwitchDirection(collision);
    }

    public override void OnStomp()
    {
        Debug.Log("100");
        Destroy(gameObject);
    }
}
