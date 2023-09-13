using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject AreYouSurePanel;
    public void play()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }
    public void AreYouSure()
    {
        PauseScreen.SetActive(false);

        AreYouSurePanel.SetActive(true);

    }
    public void No() 
    {
        AreYouSurePanel.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);

        }
    }
}
