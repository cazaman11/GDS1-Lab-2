﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int score;
    [SerializeField]
    private Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        scoreText.text = score.ToString();
	}

    public void AddPoints (int points)
    {
        score += points;
    }
}
