using UnityEngine;
using System.Collections;

public class cameraSript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<NetworkView>().isMine){
			//GetComponent(Camera).enabled = true;
			gameObject.SetActive(true);
		}
		else{
			gameObject.SetActive(false);
			//GetComponent(Camera).enabled = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
