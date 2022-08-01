using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//ADDED TO DOC

public class Health : MonoBehaviour
{
    public int numOfHearts;
    //Number of hearts remaining

    public Image[] hearts;
    //Images of each heart is stored in this array

    public void SetHealth(Player player)
    //We can set the health of each unique player in the game
    {
        numOfHearts = player.Hearts;
        //numOfHearts variable is stored as player's global variable hearts
        //This is so that each player's number of hearts will be independent from one and another
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        //For when index is at the start of the array, doesn't exceed the array size and index increments
        {
            if (i < numOfHearts)
            //If index is smaller than the number of hearts the player has
            {
                hearts[i].enabled = true;
                //Heart of index i will be shown
            }
            else
            {
                hearts[i].enabled = false;
                //Heart of index i will not be shown if i is not smaller than the player's number of hearts
            }
        }
    }
}

