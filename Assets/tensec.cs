using UnityEngine;
using System.Collections;

public class tensec : MonoBehaviour {

	// Use this for initialization
	public int count;
	// Use this for initialization
	void Start () {
		count = 0;
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 100) {
			gameObject.SetActive (false);
		} else if (count > 200) {
			gameObject.SetActive (true);
		}
		else if (count > 200) {
			gameObject.SetActive (false);
		}
		count++;

	}
}
