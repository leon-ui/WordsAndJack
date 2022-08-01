using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using Random = UnityEngine.Random;

//ADDED TO DOC

public class LetterRandomiser : MonoBehaviour
{
    public char[] letters = { 'a' };
    //All letters of the alphabet stored in array except for J,Q,X and Z

    public char[] commonletters;
    //Common letters are stored in this array for the hard difficulty of the game

    public static string lettersToCompare;
    //Randomly generated letters

    public static string userInput;
    //Word entered by the player

    public Text displayLetters;
    //Show the randomly generated letters on the screen

    public InputField enterWord;
    //Input field for player to input word

    public string[] EnglishDictionary;
    //Stores all words in the English dictionary in array

    public BattleSystem battleSystem;
    //References BattleSystem script

    public bool isMatchingAllLetters;
    //Checks whether the word matches all of the letters displayed on the screen

    public bool SwitchDifficulty;
    //Changes the difficulty of the game

    void Start()
        //As soon as the game starts
    {
        Generate2Letters();
        //Generate two random letters via this function

        SwitchDifficulty = false;
        //Don't switch the difficulty yet

        EnglishDictionary = System.IO.File.ReadAllLines(@"C:\Users\lluc\Downloads\corncob_lowercase.txt");
        //Assigning the text file to the variable EnglishDictionary
    }

    public void Generate2Letters() 
        //Generates two random letters
    {
        System.Random r = new System.Random();
        //Generates a random character to be the index of letters

        lettersToCompare = "";
        //Assign lettersToCompare with an empty string

        for (int i = 0; i < 2; i++)
        //For 2 increments of i
        {
            lettersToCompare += letters[r.Next(0, letters.Length)].ToString();
            //Randomise letter and convert it to string
        }

        displayLetters.text = lettersToCompare;
        //Assign the two letters to the displayLetters text field so players can see those letters
    }

    public void Generate3Letters()
        //Generates three random letters
    {
        if (battleSystem.numofrounds >= 10)
        //If 5 rounds or more have passed
        {
            System.Random r = new System.Random();
            //Generates a random character to be the index of letters

            lettersToCompare = "";
            //Assign lettersToCompare with an empty string

            for (int i = 0; i < 3; i++)
            //For 3 increments of i
            {
                lettersToCompare += commonletters[r.Next(0, commonletters.Length)].ToString();
                //Randomise letter and convert it to string
            }

            displayLetters.text = lettersToCompare;
            //Assign the three letters to the displayLetters text field so players can see those letters

            print("You have not inputted a correct word with all 3 letters, try again!");
        }
    }

    public void MatchLetters()
        //Checks if the word matches the letters
    {
        userInput = enterWord.text;
        //Text from input field enterWord is converted into a string value

        isMatchingAllLetters = true;
        //Remains true if the string value does contain the letters

        foreach (char c in lettersToCompare)
        //For each letter in the letters displayed on the screen
        {
            //If the string value does not contain ALL of the displayed letters
            if (!userInput.Contains(c))
            {
                isMatchingAllLetters = false;
                //The word doesn't match all of the letters
            }
        }
    }

    void wordIsInFile(string userword)
        //Passes the parameter string value word 
    {
        foreach (var dictword in EnglishDictionary)
            //For each word in the text file
        {
            if (userword == dictword && battleSystem.state == BattleState.PLAYER1TURN)
                //If the word inputted by the user matches a word in the text file and it's player 1's turn
            {
                Generate2Letters();
                //Generate another 2 random letters

                enterWord.text = "";
                //Clear the input field

                battleSystem.numofrounds = battleSystem.numofrounds + 1;
                //Increment number of rounds

                battleSystem.currentTime = 10;
                //Reset current time on timer to 10

                battleSystem.state = BattleState.PLAYER2TURN;
                //Switch turns with player 2

                battleSystem.Player2Turn();
                //Player 2's go

                Generate3Letters();
                //Generate 3 random letters if the conditions are met for the function
            }
            else if (userword == dictword && battleSystem.state == BattleState.PLAYER2TURN)
            //If the word inputted by the user matches a word in the text file and it's player 2's turn
            {
                Generate2Letters();
                //Generate another 2 random letters

                enterWord.text = "";
                //Clear the input field

                battleSystem.numofrounds = battleSystem.numofrounds + 1;
                //Increment number of rounds

                battleSystem.currentTime = 10;
                //Reset current time on timer to 10

                battleSystem.state = BattleState.PLAYER1TURN;
                //Switch turns with player 1

                battleSystem.Player1Turn();
                //Player 1's go

                Generate3Letters();
                //Generate 3 random letters if the conditions are met for the function
            }
        }
    }

    void Update() //Execute following code every frame
    {

        if (Input.GetKeyDown(KeyCode.Return)
            && isMatchingAllLetters == true)
            //If the enter key is pressed and the word matches all of the letters displayed to the player
        {
            wordIsInFile(enterWord.text);
            //Pass in the text inputted by the player as a parameter

            MatchLetters();
            //Checks if the letters match with player's input

            print("Word has been accepted");
        }
        else if (Input.GetKeyDown(KeyCode.Return)
            && isMatchingAllLetters == false)
        //If the enter key is pressed and the word doesn't match all of the letters displayed to the player
        {
            enterWord.text = "";
            //Clear input field

            MatchLetters();
            //Checks if the letters match with player's input

            print("Word has been rejected please try again");
        }
        else if (Input.GetKeyDown(KeyCode.Return)
        && isMatchingAllLetters == true
        && battleSystem.state == BattleState.PLAYER2TURN)
        //If the enter key is pressed and the word does match all of the letters displayed to the player amd it's player 2's turn
        {
            battleSystem.state = BattleState.PLAYER1TURN;
            //Switch turns with player 1

            battleSystem.Player1Turn();
            //Player 1's go

            wordIsInFile(enterWord.text);
            //Pass in the text inputted by player 1 as a parameter
        }

        MatchLetters();
        //Checks if the letters match with player's input
    }
}
