using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {
	public Canvas canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onClick(){
		canvas.enabled = false;
		Debug.Log ("on click");
	}
}
