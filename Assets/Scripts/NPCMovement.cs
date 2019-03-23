using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    private bool goLeft;
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Awake()
    {
        SetUp();
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

    public virtual void SwitchDirection(Collision collision) {
        if (GetDirectionOfCollision(collision) == Vector3.right || GetDirectionOfCollision(collision) == Vector3.left)
        {
            goLeft = !goLeft;
        }
    }

    public virtual void Move() {
        if (goLeft)
        {
            transform.position += Vector3.left * speed;
        }
        else
        {
            transform.position += Vector3.right * speed;
        }
    }

    public virtual void SetUp() {
        goLeft = true;
    }

    public virtual void OnStomp() {
    }

    public virtual void Die() {
        Destroy(gameObject);
    }

    public bool IsGoingLeft() {
        return goLeft;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetDirection(bool isLeft) {
        goLeft = isLeft;
    }

    public Vector3 GetDirectionOfCollision(Collision collision)
    {
        Vector3 direction = (collision.transform.position - transform.position);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycast;
        Physics.Raycast(ray, out raycast);
        if (raycast.collider)
        {
            Vector3 normal = raycast.normal;
            normal = raycast.transform.TransformDirection(normal);
            if (normal == raycast.transform.up)
            {
                return Vector3.down;
            }
            if (normal == -raycast.transform.up)
            {
                return Vector3.up;
            }
            if (normal == raycast.transform.right)
            {
                return Vector3.left;
            }
            if (normal == -raycast.transform.right)
            {
                return Vector3.right;
            }
        }
        return Vector3.zero;
    }
}
