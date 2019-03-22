using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour {

    public int lives = 3;
    int coinTotal; //Make this link to coin script
    CoinManager coinManagerScript ;
    bool checkpointPassed = false; //Add checkpoint object to flag if passed
	// Use this for initialization
	void Start () {
        coinManagerScript = gameObject.GetComponent<CoinManager>();
        coinTotal = coinManagerScript.coinTotal;
	}
	
	// Update is called once per frame
	void Update () {
        coinTotal = coinManagerScript.coinTotal;
		if(lives == 0)
        {
            GameOver();
        }
        if(coinTotal == 100)
        {
            coinTotal = 0;
            OneUp();
        }
        if(lives > 100)
        {
            lives = 100;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameOver();
        }
	}

    public void OneUp()
    {
        lives += 1;
    }

    public void Died()
    {
        lives -= 1;
        // Move mario to world spawn or checkpoint
        // Move camera there
        // Might make separate scenes for easy loading of objects
        SceneManager.LoadScene("GameScene");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameScene");
        lives = 3;
        coinManagerScript.coinTotal = 0;
    }
}
