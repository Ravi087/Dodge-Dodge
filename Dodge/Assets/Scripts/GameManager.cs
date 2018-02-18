using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager instance;

    public bool game_OverActivated;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        game_OverActivated = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        ScoreManager.instance.StartScore();
       
    }

    public void GameOver()
    {
        game_OverActivated = false;
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
         UnityAdManager.instance.ShowAds();
       // UnityAdManager.instance.ShowWorld();
    }
    
}
