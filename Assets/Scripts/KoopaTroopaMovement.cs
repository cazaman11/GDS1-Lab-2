﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopaMovement : NPCMovement {

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
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void OnStomp() {
        if (standing)
        {
            standing = false;
            shell.SetActive(true);
            body.SetActive(false);
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddPoints(100);
        }
        else {
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddPoints(400);
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

    public override void SetUp()
    {
        base.SetUp();
        Stand();
        shellSpeed = GetSpeed() * 2;
        timeToStand = 5;
        t = 0;
    }

    public override void Move()
    {
        if (standing)
        {
            if (IsGoingLeft())
            {
                transform.position += Vector3.left * GetSpeed();
            }
            else
            {
                transform.position += Vector3.right * GetSpeed();
            }
        }
        else
        {
            if (canShellMove)
            {
                if (IsGoingLeft())
                {
                    transform.position += Vector3.left * shellSpeed;
                }
                else
                {
                    transform.position += Vector3.right * shellSpeed;
                }
            }
            else
            {
                if (t >= 1)
                {
                    Stand();
                    t = 0;
                }
                else
                {
                    t += Time.deltaTime / timeToStand;
                }
            }
        }
    }

    public override void SwitchDirection(Collision collision)
    {
        if (collision.transform.tag == "Player" && GetDirectionOfCollision(collision) == Vector3.up)
        {
            OnStomp();
        }
        else {
            base.SwitchDirection(collision);
        }
    }
}
