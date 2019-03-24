using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {
    [SerializeField]
    GameObject[] pointBoxes;
    public bool goalTouch = false;

    private void Update()
    {
        if(goalTouch)
        {
            foreach (GameObject boxes in pointBoxes)
            {
                boxes.GetComponent<BoxCollider>().enabled = false;
            }


        }
    }
}
