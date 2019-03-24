using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoints : MonoBehaviour {
    private string thisName;
    private int points;
    private bool Top = false;   
    private void Start()
    {
        thisName = gameObject.name;
        
        if(thisName == "Top")
        {
            points = 0;
            Top = true;
        }
        else
        {
            points = int.Parse(thisName);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mario")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            if(Top)
            {
                GameObject.Find("GameManager").GetComponent<LivesScript>().OneUp();
            }

            GameObject.Find("Goal").GetComponent<GoalManager>().goalTouch = true;
        }
    }
}
