using UnityEngine;
using System.Collections;

public class canvasOnCLick: MonoBehaviour {

    public Canvas park;
    public Canvas city;
    public Canvas mountain;


    // Use this for initialization
    void Start () {
        park.enabled = true;
        mountain.enabled = false;
        city.enabled = false;
    }


    // Use this for initialization
    public void LoadCityCanvas()
    {
        city.enabled = true;
        mountain.enabled = false;
        park.enabled = false;
    }

    // Use this for initialization
    public void LoadParkCanvas()
    {
        park.enabled = true;
        mountain.enabled = false;
        city.enabled = false;
    }

    // Use this for initialization
    public void LoadMountainCanvas()
    {
        mountain.enabled = true;
        park.enabled = false;
        city.enabled = false;
    }
}
