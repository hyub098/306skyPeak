using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoringScore : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//var input = gameObject.GetComponent<usernameField>();
		//input.onEndEdit.AddListener(SubmitScore);
	
	}
	
	// Update is called once per frame
	private void SubmitScore(string arg0) {
		Debug.Log (arg0);
	}
}
