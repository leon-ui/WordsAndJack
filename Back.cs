using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ADDED TO DOC

public class Back : MonoBehaviour
{
    public GameObject tutorialScreen;
    //Tutorial screen

    public GameObject settingScreen;
    //Setting screen

    public GameObject playScreen;
    //Play screen

    public GameObject mainMenu;
    //Main menu screen


    public void Lobby() //Assigned to back button on lobby scene/screen
    {
        SceneManager.LoadScene("Main Menu");
        //Goes back to main menu scene
    }

    public void PlayScreen() //Assigned to back button on play screen
    {
        playScreen.SetActive(false);
        //Hides the play screen

        mainMenu.SetActive(true);
        //Shows the main menu
    }

    public void TutorialScreen() //Assigned to back button on tutorial screen
    {
        tutorialScreen.SetActive(false);
        //Hides the tutorial screen

        mainMenu.SetActive(true);
        //Shows the main menu
    }

    public void SettingScreen() //Assigned to back button on settings screen
    {
        settingScreen.SetActive(false);
        //Hides the settings screen

        mainMenu.SetActive(true);
        //Shows the main menu
    }
}
