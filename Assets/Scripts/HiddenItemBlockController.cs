using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItemBlockController : MonoBehaviour {

    [SerializeField]
    private GameObject item;
    private bool isEmpty;
    [SerializeField]
    private bool isHidden;

    private void Awake()
    {
        isEmpty = false;
        if (isHidden)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEmpty)
        {
            if (IsCollisionBelow(collision))
            {
                if (collision.transform.tag == "Player")
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    SummonItem(item);
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

    private void SummonItem(GameObject item)
    {
        Instantiate(item, transform.position + (Vector3.up * 0.2f), Quaternion.identity);
        isEmpty = true;
    }
}
