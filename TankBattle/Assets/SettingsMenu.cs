using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer mixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currRes = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currRes;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int index)
    {
        Resolution newRes = resolutions[index];
        Screen.SetResolution(newRes.width, newRes.height, Screen.fullScreen);
    }
}
