using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : NPCMovement {

    private Rigidbody rb;
    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        SetUp();
        SetDirection(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwitchDirection(collision);
    }

    private void Update()
    {
        Move();
    }

    public override void SetUp()
    {
        base.SetUp();
        rb = GetComponent<Rigidbody>();
    }

    public override void Move()
    {
        if (IsGoingLeft())
        {
            rb.AddForce(Vector3.left * GetSpeed(), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(Vector3.right * GetSpeed(), ForceMode.Impulse);
        }
    }

    private void Bounce()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public override void SwitchDirection(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().PickUp(gameObject);
            Destroy(gameObject);
        }
        else
        {
            if (GetDirectionOfCollision(collision) == Vector3.down)
            {
                Bounce();
            }
            else {
                base.SwitchDirection(collision);
            }
        }
    }
}
