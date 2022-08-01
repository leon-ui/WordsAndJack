using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ADDED TO DOC

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    //A variable used to record whether the game is paused or unpaused

    public GameObject pauseMenu;
    //Pause menu

    public GameObject player1;
    //Player 1's avatar

    public GameObject player2;
    //Player 2's avatar

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        //If the escape button is pressed 
        {
            if (GameIsPaused) 
            //If game isn't paused
            {
                Resume();
                /*When GameIsPaused = true, the player would have already pressed the escape button
                when the game was already paused therefore we want to resume the game.*/

                print("Game has been resumed");
            } else
            {
                Pause();
                /*Otherwise if the game isn't paused, resume the game, the player has already pressed 
                the escape key while the game was not paused so we want to pause the game.*/

                print("Game has been paused");
            }
        }
    }

    public void Resume () //Assigned to the resume button on pause menu
    {
        pauseMenu.SetActive(false);
        //Hides pause menu

        Time.timeScale = 1f;
        //Resume the game when the player clicks on the resume button

        GameIsPaused = false;
        //Game will not be paused

        player1.SetActive(true);
        player2.SetActive(true);
        //Show the player avatars

        print("Game has been resumed");
    }

    public void Pause () 
    {
        pauseMenu.SetActive(true);
        //Shows pause menu

        Time.timeScale = 0f;
        //Freezes the game whilst the game is paused

        GameIsPaused = true;
        //Game is paused

        player1.SetActive(false);
        player2.SetActive(false);
        //Hide the player avatars
    }

    public void MainMenu () //Assigned to the quit button on pause menu
    {
        SceneManager.LoadScene("Main Menu");
        //Main menu scene is loaded up

        print("I have clicked on the quit button on the pause menu");
    }
}
