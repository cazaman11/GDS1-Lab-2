using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Mario" && collision.gameObject.tag != "MainCamera")
        {
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.name == "Mario")
        {
            GameObject.Find("GameManager").GetComponent<LivesScript>().Died();
        }
    }
}
