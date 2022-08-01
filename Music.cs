using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ADDED TO DOC

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    //MP3 file for music is stored as audioSource

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        //Play the music
    }
}
