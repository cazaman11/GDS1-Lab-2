using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    public int coinTotal = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(coinTotal >= 100)
        {
            coinTotal = 0;
        }
	}

    public void IncreaseCoin()
    {
        coinTotal += 1;
    }
}
