using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		transform.position=new Vector3(150+50*Random.value, 150,150+50*Random.value );
	}
	
	// Update is called once per frame
	void Update () {
        // hi there
		
	}
}