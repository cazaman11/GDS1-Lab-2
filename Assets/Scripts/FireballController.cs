using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : NPCMovement {

    private PlayerController pc;
    private Rigidbody rb;
    private Vector3 dir;
    private bool canMove;
    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        SetUp();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<NPCMovement>().Die();
            Die();
        }
        else {
            if (GetDirectionOfCollision(collision) == Vector3.down)
            {
                Bounce();
            }
            else {
                Die();
            }
        }
    }

    private void Update()
    {
        Move();
    }

    public override void SetUp()
    {
        base.SetUp();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        canMove = false;
    }

    public override void Die()
    {
        pc.fireballHit();
        base.Die();
    }

    public override void Move()
    {
        if (canMove) {
            rb.AddForce(dir * GetSpeed(), ForceMode.Impulse);
        }
    }

    public void Fire(Vector3 direction) {
        dir = direction;
        canMove = true;
    }

    private void Bounce() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
