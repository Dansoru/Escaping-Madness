using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Unity.VisualScripting;
using TMPro;

public class Menu : MonoBehaviour
{

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;

    void Start(){
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + "hz";
            options.Add(option);
            if (resolutions[1].width == Screen.currentResolution.width && resolutions[1].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution (int ResolutionIndex){
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void empezarNivel(string Nivel){
        SceneManager.LoadScene("Nivel");
    }

    public void Salir(){
        Application.Quit();
    }

    public AudioMixer audioMixer;

    public void defVolumen(float volumen){
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void defCalidad(int calidad){
        QualitySettings.SetQualityLevel(calidad);
    }
    
    public void defFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    
}
