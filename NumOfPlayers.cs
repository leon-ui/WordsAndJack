using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ADDED TO DOC

public class NumOfPlayers : MonoBehaviour
{
    public InputField NumOfPlayersIF; //referencing input field that sets number of players
    public GameObject Player1; //referencing player 1
    public GameObject Player2; //referencing player 2
    public GameObject avatarcreator1; //referencing the avatar creator assigned to player 1
    public GameObject avatarcreator2; //referencing the avatar creator assigned to player 2

    public void SettingNum() //setting number of players function
    {
        if (NumOfPlayersIF.text == "1") //if 1 is typed into input field
        {
            Player2.SetActive(false); //deactivate player 2
            Player1.SetActive(true); //activate player 1
            avatarcreator2.SetActive(false); //hide avatar creator assigned to player 2
            avatarcreator1.SetActive(true); //show avatar creator assigned to player 1
            Debug.Log("Only 1 player will be instantiated/spawned into the game");
        }
        else if (NumOfPlayersIF.text == "2") //if 2 is typed into input field
        {
            //activate both players and their avatar creators
            Player2.SetActive(true); 
            Player1.SetActive(true); 
            avatarcreator1.SetActive(true);
            avatarcreator2.SetActive(true);
            Debug.Log("2 players will be instantiated/spawned into the game");
        }
    }
}
