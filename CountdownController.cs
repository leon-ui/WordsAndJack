using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//ADDED TO DOC

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    //Text to display the timer decrementing

    public GameObject countDownDisplay;
    //Countdown panel

    public InputField enterWord;
    //Input field used to enter a word

    public GameObject Jackbox;
    //Jackbox that's shown in the middle of the screen

    void Start() //At the start of the game...
    {
        countDownDisplay.gameObject.SetActive(true);
        //Show the countdown panel

        StartCoroutine(CountDown());
        //Call countdown function

        enterWord.gameObject.SetActive(false);
        //Hide the enterWord input field 

        Jackbox.SetActive(false);
        //Hide the jack in the box
    }

    IEnumerator CountDown()
    {
        countDownText.text = "5";
        //5 is shown on the text displaying timer

        yield return new WaitForSeconds(1f);
        countDownText.text = "4";
        //After 1 second had passed after timer text showed 5, 4 is shown on the text displaying timer

        yield return new WaitForSeconds(1f);
        countDownText.text = "3";
        //After 2 seconds had passed after timer text showed 5, 3 is shown on the text displaying timer

        yield return new WaitForSeconds(1f);
        countDownText.text = "2";
        //After 3 second had passed after timer text showed 5, 2 is shown on the text displaying timer

        yield return new WaitForSeconds(1f);
        countDownText.text = "1";
        //After 4 second had passed after timer text showed 5, 1 is shown on the text displaying timer

        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
        countDownDisplay.SetActive(false);
        enterWord.gameObject.SetActive(true);
        Jackbox.SetActive(true);
        //After 5 second had passed after timer text showed 5, show game components like...
        //enterWord input field and the jack in the box.

        //but hide the countdown components like...
        //the text to display the timer and the countdown panel.
    }
}
