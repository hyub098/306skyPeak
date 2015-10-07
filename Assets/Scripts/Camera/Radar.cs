using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * 
 * Reference to Youtuber:Florian M
 */

public class Radar : MonoBehaviour {

	public GameObject[] trackerdObjs;
	public GameObject radarPrefab;
	List<GameObject> radarObjs; 
	List<GameObject> borderObjs; 
	public float switchDist;
	public Transform helpTransform;
	public GameObject player;


	// Use this for initialization
	void Start () {
		createRadarObj ();

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 18.1f, player.transform.position.z);


		for(int i =0; i<radarObjs.Count;i++){
			if(Vector3.Distance(radarObjs[i].transform.position,transform.position) > switchDist){

				//switch to border
				helpTransform.LookAt(radarObjs[i].transform);
				borderObjs[i].transform.position = transform.position + switchDist * helpTransform.forward;

//				borderObjs[i].layer = LayerMask.NameToLayer("Radar");
//				radarObjs[i].layer = LayerMask.NameToLayer("Invisible");
			}
			else{
//				borderObjs[i].layer = LayerMask.NameToLayer("Invisible");
//				radarObjs[i].layer = LayerMask.NameToLayer("Radar");

			}
			 
		}
	}


	void createRadarObj(){
		radarObjs = new List<GameObject> ();
		borderObjs = new List<GameObject>();

		foreach (GameObject o in trackerdObjs) {
			GameObject k = Instantiate(radarPrefab,o.transform.position,Quaternion.identity) as GameObject;
			radarObjs.Add(k);


			GameObject j = Instantiate(radarPrefab,o.transform.position,Quaternion.identity) as GameObject;
			borderObjs.Add(j);
		}
	}
}
