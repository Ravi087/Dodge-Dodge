using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class UnityAdManager : MonoBehaviour {


    public static UnityAdManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }
    }

    public void ShowWorld()
    {
        if(PlayerPrefs.HasKey("AdCount"))
        {
            if(PlayerPrefs.GetInt("AdCount") == 3)
            {
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    Advertisement.Show("rewardedVideo");
                }
                PlayerPrefs.SetInt("AdCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCount", PlayerPrefs.GetInt("AdCount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdCount", 0);
        }
    }
}
