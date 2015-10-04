using UnityEngine;
using System.Collections;

public class randomFalling : MonoBehaviour {
	int flyCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		flyCount++;
		if (flyCount > 1000) {
			transform.position=new Vector3(100+500*Random.value, 400,800*Random.value );
			flyCount=0;
		}
		
		
		
	}
}
