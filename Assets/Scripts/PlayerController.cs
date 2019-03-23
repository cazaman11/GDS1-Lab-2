using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private enum State { Small, Super, Fire, Star };
    private State currentState;

    private enum SpeedState { Walk, Run};
    private SpeedState currentSpeedState;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runMulti;

    [SerializeField]
    private float jumpForce;
    private bool canJump;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
        currentState = State.Small;
        currentSpeedState = SpeedState.Walk;
        canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpeedState();
        Move();
        Jump();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (currentSpeedState == SpeedState.Walk)
            {
                rb.AddForce(Vector3.left * walkSpeed);
            }
            else
            {
                rb.AddForce(Vector3.left * walkSpeed * runMulti);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (currentSpeedState == SpeedState.Walk)
            {
                rb.AddForce(Vector3.right * walkSpeed);
            }
            else
            {
                rb.AddForce(Vector3.right * walkSpeed * runMulti);
            }
        }        
    }

    private void UpdateSpeedState() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeedState = SpeedState.Run;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeedState = SpeedState.Walk;
        }
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (canJump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HasLanded(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void HasLanded(Collision collision) {
        if (!canJump)
        {
            if (GetDirectionOfCollision(collision) == Vector3.down) {
                if (collision.transform.tag != "Enemy")
                {
                    canJump = true;
                }
                else {
                    collision.gameObject.GetComponent<EnemyMovement>().OnStomp();
                }
            }
        }
    }

    private Vector3 GetDirectionOfCollision(Collision collision) {
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
