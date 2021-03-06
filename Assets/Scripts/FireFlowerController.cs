﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerController : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") {
            collision.gameObject.GetComponent<PlayerController>().PickUp(gameObject);
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddPoints(1000);
            Destroy(gameObject);
        }
    }
}
