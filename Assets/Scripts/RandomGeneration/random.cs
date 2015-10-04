using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );
	}
	
	// Update is called once per frame
	void Update () {
        // hi there
		
	}
}