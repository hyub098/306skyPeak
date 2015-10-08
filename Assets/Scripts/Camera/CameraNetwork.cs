using UnityEngine;
using System.Collections;

public class CameraNetwork : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<NetworkView>().isMine){
			gameObject.SetActive(true);
		}
		else{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
