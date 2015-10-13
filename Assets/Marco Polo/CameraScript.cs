using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public bool isMine=false;
	// Use this for initialization
	void Start () {

			
	}
	
	// Update is called once per frame
	void Update () {
		if(isMine){
			gameObject.GetComponent<Camera> ().enabled = true;
		}

	}
}
