using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomMovement : NPCMovement {

    // Use this for initialization
    void Awake()
    {
        SetUp();
        SetDirection(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwitchDirection(collision);
    }

    public override void SwitchDirection(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().PickUp(gameObject);
            Destroy(gameObject);
        }
        else {
            base.SwitchDirection(collision);
        }
    }
}
