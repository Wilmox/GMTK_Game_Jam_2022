using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gameUI;

    public GameObject endScreen;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        //gameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        //gameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMainMenu() {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void LoadScoreBoard() {
        Debug.Log("Loading scoreboard");
        endScreen.SetActive(true);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
