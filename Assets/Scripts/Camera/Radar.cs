using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour {

	public GameObject[] trackerdObjs;
	public GameObject radarPrefab;
	List<GameObject> radarObjs; 


	// Use this for initialization
	void Start () {
		createRadarObj ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void createRadarObj(){
		radarObjs = new List<GameObject> ();
		Debug.Log("Script is loaded: " + gameObject.name);
		foreach (GameObject o in trackerdObjs) {
			GameObject k = Instantiate(radarPrefab,o.transform.position,Quaternion.identity) as GameObject;

			radarObjs.Add(k);
		}
	}
}
