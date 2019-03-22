using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    Camera thisCamera;
    Transform cameraTransform;
    GameObject mario;
    Vector3 distance;
    float previousX;
	// Use this for initialization
	void Start () {
        thisCamera = gameObject.GetComponent<Camera>();
        cameraTransform = gameObject.transform;
        mario = GameObject.Find("Mario");
        // distance = cameraTransform.position - mario.transform.position;
        distance.x = mario.transform.position.x;
        distance.y = cameraTransform.position.y;
        distance.z = cameraTransform.position.z;

    }
	
	// Update is called once per frame
	void Update () {
        // transform.position = mario.transform.position;
        previousX = distance.x;
	}

    void LateUpdate()
    {

        if (previousX < mario.transform.position.x)
        {
            distance.x = mario.transform.position.x;
        }

        cameraTransform.position = distance;
    }
}
