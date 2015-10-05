using UnityEngine;
using System.Collections;

public class welcomeToMap : MonoBehaviour {

	private float time = 0;

	void Start(){Time.timeScale = 1f;}
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;
		Debug.Log (time);
		if (time > 5) {
			Application.LoadLevel ("map");
		}
	}
}
