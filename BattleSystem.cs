using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ADDED TO DOC

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER1WON, PLAYER2WON }
//All possible states for the game to be in

public class BattleSystem : MonoBehaviour
{
    public GameObject player1Prefab;
    //Player 1

    public GameObject player2Prefab;
    //Player 2

    public Transform player1slot;
    //Player 1 will spawn into this slot

    public Transform player2slot;
    //Player 2 will spawn into this slot

    Player player1;
    //Retrieving property of player 1

    Player player2;
    //Retrieving property of player 2

    public Text dialogueText;
    //Text will output what state the game is in to the player

    public Health player1Health;
    //Retrieving health of player 1

    public Health player2Health;
    //Retrieving health of player 2

    public BattleState state;
    //Making battle state a variable

    public float currentTime = 0f;
    //Current time is set to 0 seconds

    float startingTime = 15f;
    //Starting time is set to 15 seconds (the time that will be set as soon as the game starts)

    public Text countdownText;
    //The value of the timer will be shown as text

    public GameObject EnterWordInputField;
    //Input field to allow the players to type in a word

    public int numofrounds;

    string P1NAME;
    //Player 1's username

    string P2NAME;
    //Player 2's username

    void Start()
    /*Start() function means that the code within this function will
     * run as soon as the game starts*/
    {
        numofrounds = 0;
        //At the start of the game, no rounds have passed therefore number of rounds is set to 0

        state = BattleState.START;
        //The state of the game is set to the start of the game

        StartCoroutine(SetupGame());
        //SetupGame() is made a coroutine so that my program runs through the whole code under SetupGame()

        currentTime = startingTime;
        //The current time is set to the starting time (15 seconds)

        P1NAME = PlayerPrefs.GetString("P1UsernameKey");
        //Player 1's username is retrieved from its assigned key set in the NameTransfer class

        P2NAME = PlayerPrefs.GetString("P2UsernameKey");
        //Player 2's username is retrieved from its assigned key set in the NameTransfer class
    }

    void Update() //Runs the code below after every frame
    {
        currentTime -= 1 * Time.deltaTime;
        //Each second, the current time will decrease by one

        countdownText.text = currentTime.ToString("0");
        //Set the text of countdownText to currentTime so the player can see the timer
        //Also I wanted to simplify our timer and not have it show decimal values as it decrements

        if (currentTime <= 0 && state == BattleState.PLAYER1TURN)
            //If our timer hits 0 and it's player 1's turn
        {
            numofrounds = numofrounds + 1;
            //Increment number of rounds

            currentTime = 0;
            //Set currentTime = 0 otherwise it will show negative values

            player1Health.numOfHearts = player1Health.numOfHearts - 1;
            //Player 1's number of hearts will decrement

            state = BattleState.PLAYER2TURN;
            //Switch turns with player 2

            Player2Turn();
            //Run Player2Turn function

            currentTime = 10;
            //Reset time to 10
        }
        else if (currentTime <= 0 && state == BattleState.PLAYER2TURN)
            //Otherwise, if our timer hits 0 and it's player 2's turn
        {
            numofrounds = numofrounds + 1;
            //Increment number of rounds

            currentTime = 0;
            //Set currentTime = 0 otherwise it will show negative values

            player2Health.numOfHearts = player2Health.numOfHearts - 1;
            //Player 2's number of hearts will decrement

            state = BattleState.PLAYER1TURN;
            //Switch turns with player 1

            Player1Turn();
            //Run Player1Turn function

            currentTime = 10;
            //Reset time to 10
        }

        else if (player1Health.numOfHearts == 0)
            //Otherwise if player 1's number of hearts falls to 0
        {
            state = BattleState.PLAYER2WON;
            //State of the game will be set to player 2 has won

            currentTime = 0;
            //Set currentTime = 0 otherwise it will show negative values

            Player2Won();
            //Run Player2Won function
        }

        else if (player2Health.numOfHearts == 0)
        //Otherwise if player 2's number of hearts falls to 0
        {
            state = BattleState.PLAYER1WON;
            //State of the game will be set to player 1 has won

            currentTime = 0;
            //Set currentTime = 0 otherwise it will show negative values

            Player1Won();
            //Run Player1Won function
        }
    }

    IEnumerator SetupGame()
        //IEnumerator function is used so we can use 'yield return' statements
    {
        GameObject player1GO = Instantiate(player1Prefab, player1slot);
        //Instantiate player 1 and spawn their avatar in the player1slot game object (which is the partially transparent
        //black square behind the player 1 prefab shown on my screenshot)

        //GO in this context stands for game object

        player1 = player1GO.GetComponent<Player>();
        //Assign variable player1 with the player class script 

        GameObject player2GO = Instantiate(player2Prefab, player2slot);
        //Instantiate player 1 and spawn their avatar in the player1slot game object

        player2 = player2GO.GetComponent<Player>(); 
        //Assign variable player2 with the player class script 

        dialogueText.text = "GET READY!";
        //When the game is being set up, the dialogue will show GET READY

        player1Health.SetHealth(player1);
        //Set player 1's health by calling the SetHealth function from the Health script

        player2Health.SetHealth(player2);
        //Set player 2's health by calling the SetHealth function from the Health script

        yield return new WaitForSeconds(5f);
        //Return wait for 5 seconds before executing the code below

        state = BattleState.PLAYER1TURN;
        //It's player 1's turn

        Player1Turn(); //player 1's turn
        //Run Player1Turn function
    }

    public void Player1Turn()
    {
        dialogueText.text = P1NAME + "'s turn.";
        //Show to the players in the dialogueText field that it's player 1's turn
    }

    public void Player2Turn()
    {
        dialogueText.text = P2NAME + "'s turn.";
        //Show to the players in the dialogueText field that it's player 2's turn
    }

    void Player2Won()
    {
        if (state == BattleState.PLAYER2WON)
            //If player 2 has won the game
        {
            dialogueText.text = P2NAME + " won!";
            //Show in the dialogueText field that they won the game

            EnterWordInputField.SetActive(false);
            //Hide the enter word input field to not allow players to continue playing
        }
    }

    void Player1Won()
    {
        if (state == BattleState.PLAYER1WON)
        //If player 1 has won the game
        {
            dialogueText.text = P1NAME + " won!";
            //Show in the dialogueText field that they won the game

            EnterWordInputField.SetActive(false);
            //Hide the enter word input field to not allow players to continue playing
        }
    }
}
