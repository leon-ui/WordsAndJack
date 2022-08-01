using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    Rect fpsRect;
    //2D rectangle object

    GUIStyle style; 
    /*GUI style will allow me to add a label to display frames per second,
     * as well as adjusting its font size*/

    void Start()
    {
        fpsRect = new Rect(560, 20, 400, 100);
        /*A new rectangle has been created with dimensions x:560, y:20,
         * width of 400px and height of 100px so that it's located 
         at the top right corner of the screen*/

        style = new GUIStyle();
        //Define a new GUIStyle

        style.fontSize = 30;
        //Change the font size of the GUIStyle to 30
    }
    void OnGUI()
    {
        float fps = 1 / Time.deltaTime;
        //Frames per second value

        GUI.Label(fpsRect, "FPS: " + fps);
        /*A new label has been created and it's defined using the positions
         * I set for fpsRect, its text will display FPS: and then the
         * frames per second value*/
    }
}
