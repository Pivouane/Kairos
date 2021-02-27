using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  // recupere l'audio
    Resolution[] resolutions;      // recupere les differentse résolutiions possibles pour un setup 
    public Dropdown dropdown;      // recupere le menu deroulant 


    public void Start()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions(); // on efface tout les menu deroulants préfaits
        List<string> options = new List<string>();
        int index = 0; 

        for (int i = 0; i < resolutions.Length; i++) // boucle qui recuperer toutes les resolutions et la stocke dans une liste
        {
            string tmp = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(tmp); 

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                index = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = index;
        dropdown.RefreshShownValue();
        Screen.fullScreen = true; 
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void FullScreen(bool isScreen)
    {
        Screen.fullScreen = isScreen;
    }
    public void Resolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
  
}
