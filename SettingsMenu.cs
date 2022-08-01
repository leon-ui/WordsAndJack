using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//ADDED TO DOC

public class SettingsMenu : MonoBehaviour{

    public AudioMixer audioMixer; 
    //Unity's audio mixer

    public void SetVolume (float volume) 
    //SetVolume function takes in the value volume as a float
    {
        audioMixer.SetFloat("volume", volume); 
        //Unity's audio mixer will set the value of itself as the value set via volume slider
    }

    public void SetQuality (int qualityIndex) 
    //SetQuality function takes in the value qualityIndex as an integer
    {
        QualitySettings.SetQualityLevel(qualityIndex); 
        //Unity's graphical settings will change depending on the quality level set by the player using the dropdown
    }

    public void SetFullscreen (bool isFullscreen) 
    //SetFullscreen function takes in the value isFullscreen as a boolean value
    {
        Screen.fullScreen = isFullscreen; 
        //When fullscreen toggle is toggled on, the screen now becomes fullscreen and vice versa
    }

    //Resolutions 
    List<int> widths = new List<int>() {1280, 1600, 1920}; 
    List<int> heights = new List<int>() {720, 900, 1080};

    public void SetScreenSize (int index) 
    //SetScreenSize function takes in the value index as an integer
    {
        bool fullscreen = Screen.fullScreen;
        //Resolution needs to take in three arguments so Screen.fullscreen has to be assigned to fullscreen variable

        int width = widths[index]; 
        //Integer width variable is assigned the value of the width that is chosen by the player from the list of widths

        int height = heights[index]; 
        //Integer height variable is assigned the value of the height that is chosen by the player from the list of widths

        Screen.SetResolution(width, height, fullscreen); 
        //Resolution is set by taking in the values height and width
    }
}
