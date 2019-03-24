using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipecontroller : MonoBehaviour {

    [SerializeField]
    private Vector3 direction;
    private KeyCode kc;
    [SerializeField]
    private Transform point;
    private bool canTeleport;
    private GameObject player;

    private void Awake()
    {
        SetUp();
    }

    private void Update()
    {
        if (canTeleport && player) {
            if (Input.GetKeyDown(kc))
            {
                Teleport(player);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            canTeleport = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player") {
            canTeleport = false;
            player = null;
        }
    }

    void Teleport(GameObject item) {
        item.transform.position = point.position;
        canTeleport = false;
        player = null;
    }

    void SetUp() {
        if (direction == Vector3.right)
        {
            kc = KeyCode.RightArrow;
        }
        else if (direction == Vector3.left)
        {
            kc = KeyCode.LeftArrow;
        }
        else if (direction == Vector3.up)
        {
            kc = KeyCode.UpArrow;
        }
        else if (direction == Vector3.down)
        {
            kc = KeyCode.DownArrow;
        }
        else {
            kc = KeyCode.Space;
        }
        canTeleport = false;
    }
}
