using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockController : MonoBehaviour {

    [SerializeField]
    private GameObject mushroom;
    [SerializeField]
    private GameObject flower;
    private bool isEmpty;
    [SerializeField]
    private Sprite normalSprite;
    [SerializeField]
    private Sprite emptySprite;

    private void Awake()
    {

        Restart();
    }

    private void Restart()
    {
        isEmpty = false;
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!isEmpty) {
            if (IsCollisionBelow(collision.collider))
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsCollisionBelow(other))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        
    }

    private bool IsCollisionBelow(Collider collision)
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
        Empty();

    }

    private void Empty() {
        isEmpty = true;
        GetComponent<SpriteRenderer>().sprite = emptySprite;
    }
}
