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
		if (flyCount > 200) {
			transform.position=new Vector3(0, 6,13);
			flyCount=0;
		}
		
		
		
	}
}
