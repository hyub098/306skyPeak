using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
* ClickOnStart is used at the beginning of multiplayer scene. It counts three seconds and displays
* 3, 2, 1 and Go on the screen to tell the player the game starts.
*/
public class ClickOnStart : MonoBehaviour {

    public Canvas start3;
    public Button startButton;

    public Text n;

    private bool start = false;
    private bool zero = false;
    private bool one = false;
    private bool two = false;
    private bool three = false;
    private float realtime;
    private float starttime;

    // Use this for initialization
    void Start()
    {
        start3.enabled = false;
        starttime = 0;
        realtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        realtime = Time.deltaTime + realtime;
        if (start)
        {
            // count down to 2
            if (realtime - starttime > 1 && three)
            {
                startButton.enabled = false;
                n.text = ""+2;
                three = false;
                two = true;
            }
            // count down to 1
            else if (realtime - starttime > 2 && two)
            {
                n.text = ""+1;
                two = false;
                one = true;
            }
            // count down to 0
            else if (realtime - starttime > 3 && one)
            {
                n.text = "Go";
                one = false;
                zero = true;
            }
            // refresh all private fields and wait for the next call
            else if (realtime - starttime > 4 && zero)
            {
                zero = false;
                start = false;
                start3.enabled = false;
                startButton.enabled = true;
            }
        }
    }
    
    //When the player click on the start button, the number will count down.
    //It activated the function in update().  
    public void StartGame()
    {
        start = true;
        three = true;
        starttime = realtime;
        Debug.Log("start game");
    }
}
