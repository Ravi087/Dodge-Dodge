using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;


    [SerializeField]
    TextMeshProUGUI updatedScore;

    [SerializeField]
    TextMeshProUGUI mainBestScore;

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

    [SerializeField]
    float seconds;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        ispaused = false;
        mainBestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("highScore");
    }
	
	// Update is called once per frame
	void Update () {

        updatedScore.text = ScoreManager.instance.score.ToString();
        
    }

    void ShowButtonScore()
    {
        updatedScore.gameObject.SetActive(true);
        pause_Button.gameObject.SetActive(true);
    }

    void HideButtonScore()
    {
        updatedScore.gameObject.SetActive(false);
        pause_Button.gameObject.SetActive(false);

    }

    public void PausedGame()
    {
        ispaused = !ispaused;
        if(ispaused)
        {
            Time.timeScale = 0;
        }
        HideButtonScore();
        pause_MenuPanel.SetActive(true);
    }

    public void PlayGame()
    {
        ispaused = !ispaused;
        if(!ispaused)
        {
            Time.timeScale = 1;  
        }
        ShowButtonScore();
        pause_MenuPanel.SetActive(false);
    }

    public void ReloadGame()
    {
        ispaused = !ispaused;
        if(!ispaused)
        {
            Time.timeScale = 1;
            
        }
        // pause_MenuPanel.SetActive(false);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ReturnToMenu()
    {
        ispaused = !ispaused;
        if(!ispaused)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        HideButtonScore();
        gameOverMenuPanel.SetActive(true);
        gameOverCurrentScore.text = "SCORE: " + PlayerPrefs.GetInt("score");
        gameOverBestScore.text = "BEST: " + PlayerPrefs.GetInt("highScore");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

}
