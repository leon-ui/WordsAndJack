using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.Reflection;

//ADDED TO DOC

public class SceneLoader : MonoBehaviour
{
    public GameObject mainMenu; //referencing main menu screen
    public GameObject playScreen; //referencing play screen
    public GameObject tutorialScreen; //referencing tutorial screen
    public GameObject settingScreen; //referencing settings screen

    public void PlayScreen() //play screen function
    {
        mainMenu.SetActive(false); //hides main menu
        playScreen.SetActive(true); //shows play screen
        Debug.Log("The button labelled Play has been clicked on");
    }

    public void TutorialScreen() //tutorial screen function
    {
        mainMenu.SetActive(false); //hides main menu
        tutorialScreen.SetActive(true); //shows tutorial screen
        Debug.Log("The button labelled Tutorial has been clicked on");
    }

    public void SettingScreen() //settings screen function
    {
        mainMenu.SetActive(false); //hides main menu
        settingScreen.SetActive(true); //shows settings screen
        Debug.Log("The button labelled Settings has been clicked on");
    }

    public void QuitGame() //quit game function
    {
        Application.Quit(); //quits the game
        Debug.Log("The button labelled Quit has been clicked on"); //outputs a message on the console to test whether the game quits and the code runs
    }

    public void BackButton()
    {
        mainMenu.SetActive(true); //shows main menu

        //hides all other screens
        playScreen.SetActive(false); 
        tutorialScreen.SetActive(false);
        settingScreen.SetActive(false);
        Debug.Log("The button labelled Back has been clicked on");
    }
}
