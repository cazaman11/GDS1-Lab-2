using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    private int inGameTime = 400;
    private float actualTime = 0.7f;
    private float callTime = 0;
    private LivesScript lives;
    private ScoreManager scoreManager;
    [SerializeField]
    private Text timeText;
    bool pause = false;
	// Use this for initialization
	void Start () {
        lives = GameObject.Find("GameManager").GetComponent<LivesScript>();
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();

    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > callTime && !pause)
        {
            callTime = Time.time + actualTime;
            inGameTime -= 1;
        }

        if(inGameTime <= 0 && !pause)
        {
            lives.Died();
        }

        timeText.text = inGameTime.ToString();
	}

    public void timeScore()
    {
        pause = true;
        scoreManager.AddPoints(inGameTime * 50);
        inGameTime = 0;
    }
}
