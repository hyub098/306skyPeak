using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 * 
 * Reference to Youtuber:Florian M,
 * modified by: Peter Huang
 */

public class Radar : MonoBehaviour {

	public GameObject[] trackerdObjs;
	public GameObject radarPrefab;
	public List<GameObject> radarObjs; 
	public List<GameObject> borderObjs; 
	public float switchDist;
	public Transform helpTransform;
	public GameObject player;
	public GameObject mailBox;
	public GameObject mailRrefab;
	private GameObject mailRadar;
	private GameObject mailBorder;

	// Use this for initialization
	void Start () {
		createRadarObj ();


	}

	// Update is called once per frame
	void Update () {

		//Keep radar cam same position as the owl, but above it by 18.1f in y.
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 18.1f, player.transform.position.z);

		checkActive ();

		mailBorders ();
		radarBorders ();
	}


	void createRadarObj(){
		radarObjs = new List<GameObject> ();
		borderObjs = new List<GameObject>();


		//Get the objects to be tracked in the radarmap
		foreach (GameObject o in trackerdObjs) {
			GameObject k = Instantiate(radarPrefab,o.transform.position,Quaternion.identity) as GameObject;
			radarObjs.Add(k);


			GameObject j = Instantiate(radarPrefab,o.transform.position,Quaternion.identity) as GameObject;
			borderObjs.Add(j);
		}

		mailBorder = Instantiate (mailRrefab, mailBox.transform.position, Quaternion.identity) as GameObject;
		mailRadar = Instantiate (mailRrefab, mailBox.transform.position, Quaternion.identity) as GameObject;

	}

	void radarBorders(){
		//Loop through list and check if the tracked object out of sight or not
		for(int i =0; i<radarObjs.Count;i++){
			
			//if out of sight, switch to backup border object.
			if(Vector3.Distance(radarObjs[i].transform.position,player.transform.position) > switchDist){
				
				//switch to border
				helpTransform.LookAt(radarObjs[i].transform);
				borderObjs[i].transform.position = transform.position + switchDist * helpTransform.forward;
				
				borderObjs[i].layer = LayerMask.NameToLayer("Radar");
				radarObjs[i].layer = LayerMask.NameToLayer("Invisible");
			}
			else{
				borderObjs[i].layer = LayerMask.NameToLayer("Invisible");
				radarObjs[i].layer = LayerMask.NameToLayer("Radar");
				
			}
			
		}
	}


	void mailBorders(){
		//mail box border
		if (Vector3.Distance (mailBox.transform.position, player.transform.position) > switchDist) {
			helpTransform.LookAt (mailRadar.transform);
			mailBorder.transform.position = transform.position + switchDist * helpTransform.forward;
			
			mailBorder.layer = LayerMask.NameToLayer ("Radar");
			mailRadar.layer = LayerMask.NameToLayer ("Invisible");
		} else {
			mailBorder.layer = LayerMask.NameToLayer("Invisible");
			mailRadar.layer = LayerMask.NameToLayer("Radar");
		}

	}

	void checkActive(){
		foreach (GameObject o in trackerdObjs) {
			if(!o.activeSelf){
				for(int i =0 ;i <radarObjs.Count; i++){
					if(radarObjs[i].transform.position == o.transform.position){
						radarObjs[i].layer = LayerMask.NameToLayer("Invisible");
						borderObjs[i].layer = LayerMask.NameToLayer("Invisible");
						radarObjs.RemoveAt(i);
						borderObjs.RemoveAt(i);
					}
				}

			}
		}
	}
}
