using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public enum State { Small, Super, Fire, Star };
    public State currentState;
    private bool starred = false;

    private enum SpeedState { Walk, Run};
    private SpeedState currentSpeedState;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runMulti;

    [SerializeField]
    private float jumpForce;
    private bool canJump;

    private int maxBalls;
    private int currentBalls;
    [SerializeField]
    private GameObject fireball;
    private bool facingRight;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
        currentState = State.Small;
        currentSpeedState = SpeedState.Walk;
        canJump = false;
        maxBalls = 2;
        currentBalls = 0;
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpeedState();
        Move();
        Jump();
        if (currentState == State.Fire) {
            Shoot();
        }
    }

    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (currentBalls < maxBalls) {
                Fireball();
            }
        }
    }

    private void Fireball() {
        GameObject[] array;
        Vector3 dir;
        if (facingRight)
        {
            Instantiate(fireball, transform.position + (Vector3.right * 0.3f), Quaternion.identity);
            dir = Vector3.right;
        }
        else {
            Instantiate(fireball, transform.position + (Vector3.left * 0.3f), Quaternion.identity);
            dir = Vector3.left;
        }
        array = GameObject.FindGameObjectsWithTag("Fireball");
        array[array.Length - 1].GetComponent<FireballController>().Fire(dir);
        currentBalls++;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            facingRight = false;
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
            facingRight = true;
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
        if (GetDirectionOfCollision(collision) == Vector3.down)
        {
            HasLanded(collision);
        }
        else {
            if (collision.transform.tag == "Enemy") {
                if (!starred)
                {
                    Shrink();
                }
                else {
                    collision.gameObject.GetComponent<NPCMovement>().Die();
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void HasLanded(Collision collision) {
        if (!canJump)
        {
            if (collision.transform.tag != "Enemy")
            {
                canJump = true;
            }
            else
            {
                collision.gameObject.GetComponent<NPCMovement>().OnStomp();
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

    public void PickUp(GameObject item) {
        if (item.tag == "Magic Mushroom") {
            Grow();
        }
        switch (item.tag) {
            case "Magic Mushroom":
                Grow();
                break;
            case "Fire Flower":
                Ignite();
                break;
            default:break;
        }
    }

    private void Ignite() {
        if (currentState == State.Small)
        {
            Grow();
        }
        else if (currentState == State.Super)
        {
            currentState = State.Fire;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else {
            Debug.Log(1000);
        }
    }

    private void Grow() {
        if (currentState == State.Small)
        {
            currentState = State.Super;
            transform.localScale += Vector3.up;
        }
        else {
            Debug.Log(1000);
        }
    }

    private void Shrink() {
        switch (currentState) {
            case State.Fire:
                currentState = State.Super;
                break;
            case State.Super:
                currentState = State.Small;
                transform.localScale -= Vector3.up;
                break;
            case State.Small:
                Die();
                break;
        }
    }

    public void Die() {
        Debug.Log("GAME OVER!");
    }


    public bool getJump()
    {
        return canJump;
    }


    public bool IsSmall() {
        return currentState == State.Small;
    }

    public void fireballHit() {
        currentBalls--;
    }

}
