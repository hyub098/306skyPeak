using UnityEngine;
using System.Collections;

public class rotationConstraint : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x-1.5f,player.transform.position.y+2f,player.transform.position.z);

	}
}
