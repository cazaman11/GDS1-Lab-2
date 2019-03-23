using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaMovement : MonoBehaviour {

    private bool goLeft;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject shell;
    [SerializeField]
    private GameObject body;
    private bool standing;
    private float shellSpeed;
    private bool canShellMove;
    private float timeToStand;
    private float t;

    // Use this for initialization
    void Awake()
    {
        goLeft = false;
        Stand();
        shellSpeed = speed * 2;
        timeToStand = 5;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (standing)
        {
            if (goLeft)
            {
                transform.position += Vector3.left * speed;
            }
            else
            {
                transform.position += Vector3.right * speed;
            }
        }
        else {
            if (canShellMove)
            {
                if (goLeft)
                {
                    transform.position += Vector3.left * shellSpeed;
                }
                else
                {
                    transform.position += Vector3.right * shellSpeed;
                }
            }
            else {
                if (t >= 1)
                {
                    Stand();
                    t = 0;
                }
                else {
                    t += Time.deltaTime / timeToStand;
                }
            }
        }
    }

    public void Bump() {
        goLeft = !goLeft;
    }

    public void OnStomp() {
        if (standing)
        {
            standing = false;
            shell.SetActive(true);
            body.SetActive(false);
        }
        else {
            if (canShellMove)
            {
                canShellMove = false;
            }
            else {
                canShellMove = true;
            }
        }
    }

    private void Stand() {
        standing = true;
        shell.SetActive(false);
        body.SetActive(true);
        canShellMove = false;
    }
}
