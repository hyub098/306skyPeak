using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickOnStart : MonoBehaviour {

    public Canvas start3;
    //public Canvas start2;
    //public Canvas start1;
    //public Canvas go;
    //public Canvas current;
    public Canvas congratulations;
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
        congratulations.enabled = false;
        start3.enabled = true;
        //start2.enabled = false;
        //start1.enabled = false;
        //go.enabled = false;
        starttime = 0;
        realtime = 0;
        //starttime = realtime;
        //start = true;
        //three = true;
    }

    // Update is called once per frame
    void Update()
    {
        realtime = Time.deltaTime + realtime;
        if (start)
        {
            if (realtime - starttime > 1 && three)
            {
                //start3.enabled = false;
                //start2.enabled = true;
                n.text = ""+2;
                three = false;
                two = true;
            }
            else if (realtime - starttime > 2 && two)
            {
                //start2.enabled = false;
                //start1.enabled = true;
                n.text = ""+1;
                two = false;
                one = true;
            }
            else if (realtime - starttime > 3 && one)
            {
                //start1.enabled = false;
                //go.enabled = true;
                n.text = "Go";
                one = false;
                zero = true;
            }
            else if (realtime - starttime > 4 && zero)
            {
                zero = false;
                start = false;
                start3.enabled = false;
            }
        }
    }

    //public void GoToRoom()
    //{
        //current.enabled = false;
      //  start3.enabled = true;
    //}

    public void StartGame()
    {
        start = true;
        three = true;
        starttime = realtime;
        Debug.Log("start game");
        //Application.LoadLevel(level);
    }
}
