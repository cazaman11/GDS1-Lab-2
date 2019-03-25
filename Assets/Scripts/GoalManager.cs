using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {
    [SerializeField]
    GameObject[] pointBoxes;
    GameObject flag;
    Vector3 currentPos;
    Vector3 bottomPos;
    public bool goalTouch = false;
    [SerializeField]
    float time = 5f;
    private void Start()
    {
        flag = GameObject.Find("Flag");
        currentPos = flag.transform.position;
        bottomPos = GameObject.Find("FlagEnd").transform.position;
    }

    private void Update()
    {
        if(goalTouch)
        {
            foreach (GameObject boxes in pointBoxes)
            {
                boxes.GetComponent<BoxCollider>().enabled = false;
            }
            flagMove();
            // goalTouch = false;
            GameObject.Find("Time").GetComponent<TimerScript>().timeScore();
        }
    }

    void flagMove()
    {
        float t = Time.deltaTime / time;
        flag.transform.position = Vector3.Lerp(currentPos, bottomPos, t);

        
    }
}
