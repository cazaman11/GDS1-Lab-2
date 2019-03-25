using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    public int coinTotal = 0;
    [SerializeField]
    private Text coinText;
    private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
        scoreManager = gameObject.GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(coinTotal >= 100)
        {
            coinTotal = 0;
        }
        coinText.text = coinTotal.ToString();
	}

    public void IncreaseCoin()
    {
        coinTotal += 1;
        scoreManager.AddPoints(200);
    }
}
