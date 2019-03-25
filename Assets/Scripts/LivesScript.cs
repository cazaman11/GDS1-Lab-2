using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour {

    public int lives = 3;
    int coinTotal;
    CoinManager coinManagerScript ;
    bool checkpointPassed = false; //Add checkpoint object to flag if passed
    [SerializeField]
    Text livesText;
    GameObject deathScreen;
    GameObject gameOverScreen;
    TimerScript timer;
    ScoreManager scoreManager;
    // Use this for initialization
    void Start () {
        coinManagerScript = gameObject.GetComponent<CoinManager>();
        coinTotal = coinManagerScript.coinTotal;

        deathScreen = GameObject.Find("DeathScreen");
        gameOverScreen = GameObject.Find("GameOverScreen");
        deathScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        timer = GameObject.Find("Time").GetComponent<TimerScript>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
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
        livesText.text = lives.ToString();
        deathScreen.SetActive(true);
        timer.pause = true;
        Invoke("ReloadLevel", 3);
    }

    void GameOver()
    {
        //SceneManager.LoadScene("GameScene");
        gameOverScreen.SetActive(true);
        lives = 3;
        coinManagerScript.coinTotal = 0;
        scoreManager.ResetScore();
        timer.pause = true;
        Invoke("ReloadLevel", 3);
    }

    void ReloadLevel()
    {
        
        deathScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("GameScene");
        timer.timeReset();
        timer.pause = false;
    }
}
