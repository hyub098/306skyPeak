using UnityEngine;
using System.Collections;

public class TornadoMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.forward * Time.deltaTime;
	}
}
