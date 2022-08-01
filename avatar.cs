using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ADDED TO DOC

public class avatar : MonoBehaviour
{
    public SpriteRenderer AvatarFeature; 
    //Sprite renderer handles the actual image swapping so we need a reference to the sprite renderer

    public List<Sprite> options = new List<Sprite>(); 
    //Creation of a list of customisation options for our avatar

    private int currentOption = 0;
    //Keeps track of what index in the array the player is selecting

    public void NextOption()
    //Function is assigned to the right button
    {
        currentOption++; 
        /*When the button to the right is pressed, the player is going through the options list in order 
         * so we increment player's index by 1 every time the button is pressed*/

        if (currentOption >= options.Count) 
        //We need to check if we've exceeded our list size
        {
            currentOption = 0;
        //If so we need to reset it back to the first index
        }

        AvatarFeature.sprite = options[currentOption];
        //Otherwise set avatar feature to the one selected by the player
    }

    public void PreviousOption() 
    //Function is assigned to the left button
    {
        currentOption--;
        /*When the button to the left is pressed, the player is going through the options list in reverse order 
         * so we decrement player's index by 1 every time the button is pressed*/

        if (currentOption < 0)
        //We need to check if current option (our index) is smaller than 0 
        {
            currentOption = options.Count - 1;
            //Reset to the final index of the options list
        }

        AvatarFeature.sprite = options[currentOption];
        //Otherwise set avatar feature to the one selected by the player
    }

    public void Randomize() 
    //Function is assigned to the dice button
    {
        currentOption = Random.Range(0, options.Count - 1); 
        //When the dice is clicked on, currentOption will pick a random index in avatar options list

        AvatarFeature.sprite = options[currentOption];  
        //Avatar feature will be set to that randomised option
    } 
}
