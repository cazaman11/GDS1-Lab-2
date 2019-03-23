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
        if (collision.transform.tag != "Floor")
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

    public bool IsGoingLeft() {
        return goLeft;
    }

    public float GetSpeed() {
        return speed;
    }
}
