using UnityEngine;
using System.Collections;

public class fall : MonoBehaviour {
	int flyCount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		flyCount++;
		if (flyCount > 150) {

		}

		transform.position=new Vector3(5*Random.value, 0,-5*Random.value );

	}
}
