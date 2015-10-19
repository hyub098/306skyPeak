using UnityEngine;
using System.Collections;

public class ClickOnGo : MonoBehaviour {

    public Canvas start3;
    public Canvas start2;
    public Canvas start1;
    public Canvas go;
    public Canvas current;
    public Canvas congratulations;

    private bool start=false;
    private bool zero = false;
    private bool one = false;
    private bool two = false;
    private bool three = false;
    private float realtime;
    private float starttime;

    // Use this for initialization
    void Start () {
        congratulations.enabled = false;
        start3.enabled = false;
        start2.enabled = false;
        start1.enabled = false;
        go.enabled = false;
        starttime = 0;
        realtime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        realtime = Time.deltaTime + realtime;
        if (start){
            if (realtime - starttime > 1 && three)
            {
                start3.enabled = false;
                start2.enabled = true;
                three = false;
                two = true;
            }else if (realtime - starttime > 2 && two)
            {
                start2.enabled = false;
                start1.enabled = true;
                two = false;
                one = true;
            }else if (realtime - starttime > 3 && one) {
                start1.enabled = false;
                go.enabled = true;
                one = false;
                zero = true;
            }else if (realtime - starttime > 4 && zero)
            {
                go.enabled = false;
                zero = false;
                start = false;
            }
        }
    }

    public void GoToRoom()
    {
        current.enabled = false;
        start3.enabled = true;
    }

    public void StartGame()
    {
        start = true;
        three = true;
        starttime = realtime;
        //Application.LoadLevel(level);
        //System.Threading.Thread.Sleep(1000);
        //StartCoroutine(Wait());

        //start3.enabled = false;
        //start2.enabled = true;
        //StartCoroutine(Wait());
        //startTwo();
        //System.Threading.Thread.Sleep(1000);
        //start2.enabled = false;
        //start1.enabled = true;
        //System.Threading.Thread.Sleep(1000);
        //start1.enabled = false;
        //go.enabled = true;
        //System.Threading.Thread.Sleep(1000);
        //go.enabled = false;
    }

}
