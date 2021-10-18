using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float sensitivity;
    public float volume;

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelChoice");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
