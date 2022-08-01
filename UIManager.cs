using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;
using UnityEngine.SceneManagement;

//ADDED TO DOC

public class UIManager : MonoBehaviour
{
    public Dropdown BackgroundDropdown; 
    //Background drop down menu

    public Image BackgroundImage; 
    //Images that represents what each background looks like

    public Sprite[] BackgroundArray; 
    //Sprite array to assign BackgroundImage to each element in BackgroundDropdown

    public int[] BackgroundArrayIndex; 
    //Integer array to assign BackgroundDropdown elements with scene numbers

    void Start()
    {
        Debug.Log("The magnificent mix background has been selected");
    }

    void Update() 
    {
    BackgroundImage.sprite = BackgroundArray[BackgroundDropdown.value];
    //Each of the background image is assigned a value to each element of BackgroundDropdown
    }

    public void LoadScene() //Assigned to the continue button
    {
        SceneManager.LoadScene(BackgroundArrayIndex[BackgroundDropdown.value]); 
        //Loads scene depending on what background was chosen by the player via BackgroundDropdown
    }
}
