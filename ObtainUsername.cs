using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ADDED TO DOC

public class ObtainUsername : MonoBehaviour
{
    string Player1Username; 
    //Same variable used from class NameTransfer

    string Player2Username;
    //Same variable used from class NameTransfer

    public Text displayP1Username;
    //Text that we want to use to display player 1's username

    public Text displayP2Username;
    //Text that we want to use to display player 2's username


    void Start()
    {
        Player1Username = PlayerPrefs.GetString("P1UsernameKey"); 
        //Returns the value stored in Player1Username corresponding to named key

        displayP1Username.text = Player1Username; 
        //Text of displayP1Username will change to player 1's username

        Player2Username = PlayerPrefs.GetString("P2UsernameKey");
        //Returns the value stored in Player2Username corresponding to named key

        displayP2Username.text = Player2Username;
        //Text of displayP2Username will change to player 2's username
    }
}
