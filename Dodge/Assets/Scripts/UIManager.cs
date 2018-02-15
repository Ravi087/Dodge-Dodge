using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI UpdatedScore;

    [SerializeField]
    Button pause_Button;

    [SerializeField]
    GameObject pause_MenuPanel;

    [SerializeField]
    GameObject gameOverMenuPanel;

    [SerializeField]
    TextMeshProUGUI gameOverCurrentScore;

    [SerializeField]
    TextMeshProUGUI gameOverBestScore;

    bool ispaused;

	// Use this for initialization
	void Start () {
        ispaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowButtonScore()
    {
        UpdatedScore.gameObject.SetActive(true);
        pause_Button.gameObject.SetActive(true);
    }

    void HideButtonScore()
    {
        UpdatedScore.gameObject.SetActive(false);
        pause_Button.gameObject.SetActive(false);

    }
    public void PausedGame()
    {
        if(!ispaused)
        {
            ispaused = true;
            Time.timeScale = 0;
            HideButtonScore();
            pause_MenuPanel.SetActive(true);
        }
    }
    public void PlayGame()
    {
        ispaused = !ispaused;
        if(!ispaused)
        {
            Time.timeScale = 1;
            ShowButtonScore();
            pause_MenuPanel.SetActive(false);
        }
    }

    public void ReloadGame()
    {
        ispaused = !ispaused;
        if(!ispaused)
        {
            Time.timeScale = 1;
            pause_MenuPanel.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
