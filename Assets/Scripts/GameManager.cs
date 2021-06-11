using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameover;
    public GameObject complete;
    public GameObject pause;

    int health = 100;
    int score = 0;
    public static bool isPaused = false;
    

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void CompleteLevel()
    {
        complete.SetActive(true);
    }
    public void GameOver()
    {

        if (gameHasEnded != true)
        {
            gameHasEnded = true;
            gameover.SetActive(true);
           
        }
    }

}
