using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script de Mathis
public class MainMenu : MonoBehaviour
{
    public float sensitivity;
    public float volume;
    public Slider VolumeSlider;

    private void Start()
    {
        // récupération du slider
        VolumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
    }
    
    // Called when exiting the option menu
    public void SubmitVolume()
    {
        //Debug.Log(VolumeSlider.value);
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelChoice");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
