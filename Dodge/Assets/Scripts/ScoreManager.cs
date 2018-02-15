using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public int score;

    public int highScore;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ScoreIncrement()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("ScoreIncrement", 1f, .3f);
    }

    public void StopScore()
    {
        CancelInvoke("ScoreIncrement");

        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

    }
}
