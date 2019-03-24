using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockController : MonoBehaviour {

    [SerializeField]
    private GameObject mushroom;
    [SerializeField]
    private GameObject flower;
    private bool isEmpty;

    private void Awake()
    {
        isEmpty = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEmpty) {
            if (IsCollisionBelow(collision))
            {
                if (collision.transform.tag == "Player")
                {
                    if (collision.transform.GetComponent<PlayerController>().IsSmall())
                    {
                        SummonItem(mushroom);
                    }
                    else {
                        SummonItem(flower);
                    }
                }
                if(gameObject.name == "Hidden Item Block")
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    private bool IsCollisionBelow(Collision collision)
    {
        Vector3 direction = (collision.transform.position - transform.position);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycast;
        Physics.Raycast(ray, out raycast);
        if (raycast.collider)
        {
            Vector3 normal = raycast.normal;
            normal = raycast.transform.TransformDirection(normal);
            return (normal == raycast.transform.up);
        }
        return false;
    }

    private void SummonItem(GameObject item) {
        Instantiate(item, transform.position + (Vector3.up * 0.2f), Quaternion.identity);
        isEmpty = true;
    }
}
