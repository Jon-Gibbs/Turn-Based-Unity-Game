using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        qualityDropdown.value = QualitySettings.GetQualityLevel();

    }

/*
    //sets the resolution dropdown menu options to relevant options based off the user's screen
    //removed due to the resolution feature being taken out of the game
    private void setUpResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
    }
*/

    //sets the master volume based off the master voume slider value
    public void setVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void setFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
    public void OnBackButtonSelect()
    {
        SceneManager.LoadSceneAsync("Scenes/MainMenu");
    }
}
