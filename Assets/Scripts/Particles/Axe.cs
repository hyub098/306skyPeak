using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
    public GameObject owl;
    public GameObject axe;
    private float speed = 20;
    private Vector3 location;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        location = owl.transform.position;
        axe.transform.Rotate(-90f, 0.0f, 0.0f);
        axe.transform.TransformDirection(location);
    }
}
