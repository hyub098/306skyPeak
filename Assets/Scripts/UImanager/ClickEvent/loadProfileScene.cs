using UnityEngine;
using System.Collections;

public class loadProfileScene: MonoBehaviour {

    public Canvas input;
    public Canvas actualScene;



    // Use this for initialization
    void Start () {
        input.enabled = true;
        actualScene.enabled = false;
       
    }


    // Use this for initialization
    public void LoadScene()
    {
        input.enabled = false;
        actualScene.enabled = true;
        
    }


}
