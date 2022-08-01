using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ADDED TO DOC

public class AvatarRandomiser : MonoBehaviour
{
    public GameObject Player1;
    //Player 1

    public GameObject Player2;
    //Player 2

    public List<avatar> AvatarFeatures = new List<avatar>();
    //Creation of a list of all avatar features

    public InputField SetNumOfPlayers;
    //Input field that sets the number of players to be spawned into the game

    public InputField p1username;
    //Input field that stores the username entered for player 1

    public InputField p2username;
    //Input field that stores the username entered for player 1

    public GameObject usernameerror;
    //Username error screen

    public void RandomizeCharacter() //Assigned to dice button
    {
        foreach (avatar feature in AvatarFeatures) 
        //For each avatar feature in AvatarFeatures list
        {
            feature.Randomize(); 
            //Randomise avatar feature
        }
    }

    void Transfer()
    {
        PrefabUtility.SaveAsPrefabAsset(Player1, "Assets/Player.prefab");
        //When function is called, player 1's avatar will be saved at this directory

        PrefabUtility.SaveAsPrefabAsset(Player2, "Assets/Player1.prefab");
        //When function is called, player 2's avatar will be saved at this directory

        SceneManager.LoadScene("Lobby");
        //Lobby scene is loaded
    }

    public void Continue() //Assigned to continue button
    {
        if (SetNumOfPlayers.text == "1" && p1username.text == "")
        {
            usernameerror.SetActive(true); /*Username error message is shown if input field 
            contains the number 1 and username field for player 1 is empty*/
        }
        else if (SetNumOfPlayers.text == "1" && p1username.text != "")
        {
            Transfer(); /*Transfer function is run if input field contains the number 1 
            and username field for player 1 isn't empty*/
        }

        if (SetNumOfPlayers.text == "2" && p1username.text == "" || p2username.text == "")
        {
            usernameerror.SetActive(true); /*Username error message is shown if input field 
            contains the number 2 and username fields for username field for player 1 is empty 
            and/or username field for player 2 is empty*/
        }
        else if (SetNumOfPlayers.text == "2" && p1username.text != "" && p2username.text != "")
        {
            Transfer(); /*Transfer function is run if input field contains the number 2
            and username field for both players aren't empty*/
        }

        print("Continue button has been clicked");
    }
}
