using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ADDED TO DOC

public class NameTransfer : MonoBehaviour
{
    public InputField EnterP1Username;
    //Input field that stores the username entered for player 1

    public InputField EnterP2Username;
    //Input field that stores the username entered for player 2

    string Player1Username;
    //To convert text from EnterP2Username input field into a string variable

    string Player2Username;
    //To convert text from EnterP1Username input field into a string variable

    void Start() //Function is run as soon as the game starts
    {
        Player1Username = PlayerPrefs.GetString("P1UsernameKey");
        //Returns the value stored in Player1Username corresponding to named key

        EnterP1Username.text = Player1Username;
        //Stores the text inputted in EnterP1Username as string variable Player1Username

        Player2Username = PlayerPrefs.GetString("P2UsernameKey");
        //Returns the value stored in Player2Username corresponding to named key

        EnterP2Username.text = Player2Username;
        //Stores the text inputted in EnterP2Username as string variable Player2Username
    }

    public void SaveThis() //Function is assigned to continue button on play screen
    {
        Player1Username = EnterP1Username.text;
        /*Saves player 1's username as EnterP1Username input field text so player 1
         * does not have to enter their username again when restarting the game.*/

        PlayerPrefs.SetString("P1UsernameKey", Player1Username);
        //Player 1's username is set to this key

        Player2Username = EnterP2Username.text;
        /*Saves player 2's username as EnterP2Username input field text so player 2
        * does not have to enter their username again when restarting the game.*/

        PlayerPrefs.SetString("P2UsernameKey", Player2Username);
        //Player 2's username is set to this key
    }
}   
