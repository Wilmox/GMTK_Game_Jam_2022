using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene("Name");
        SceneManager.LoadScene("World Building");
    }    

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
