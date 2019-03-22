using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockScript : MonoBehaviour {

    bool isActive = false;
	// Use this for initialization

    private void activated()
    {
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mario" && !isActive)
        {
            GameObject.Find("GameManager").GetComponent<CoinManager>().IncreaseCoin();
            Invoke("activated", 10);
        }
    }
}
