using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockController : MonoBehaviour {

    [SerializeField]
    private GameObject item;
    private bool isEmpty;
    private Vector3 startPos;
    private Vector3 endPos;
    private float timeTaken;
    private float t;

    private void Awake()
    {
        if (!item)
        {
            isEmpty = true;
        }
        else {
            isEmpty = false;
        }
        startPos = transform.position;
        endPos = startPos + (Vector3.up * 0.05f);
        timeTaken = 2.5f;
        t = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEmpty) {
            if (IsCollisionBelow(collision))
            {
                if (collision.transform.tag == "Player")
                {
                    SummonItem();
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

    private void SummonItem() {
        StartCoroutine(Boop(transform.position, endPos, timeTaken, 0));
        Instantiate(item, transform.position + (Vector3.up * 0.2f), Quaternion.identity);
        isEmpty = true;
        t = 0;
        StartCoroutine(Boop(transform.position, startPos, timeTaken, 3));
    }

    private IEnumerator Boop(Vector3 start, Vector3 end, float time, float delay) {
        yield return new WaitForSeconds(delay);
        t += Time.deltaTime / time;
        transform.position = Vector3.Lerp(start, end, t);
        yield return null;
    }
}
