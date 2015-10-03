using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collision : MonoBehaviour {
	private Rigidbody rb;
	private Animation anim;
	private bool collision;
	public Text healthText;
	private int life;
	private FlyMovement flyMovement;

	// Use this for initialization
	void Start () {

		Debug.Log ("Collision script added to: " + gameObject.name);

		collision = false;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
		flyMovement = GetComponent<FlyMovement> ();
		life = 3;

	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "life:" + life;
	}

	void OnTriggerEnter(Collider other){
		collision = true;

		if (other.gameObject.CompareTag ("Terrain")) {
			life--;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{
				Debug.Log("Point of contact: "+hit.point);
				pushBack();

			}

			if(life < 1){
				flyMovement.enabled = false;
				rb.useGravity = true;
				//Move to the bottom when hit hill
				float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight (transform.position);
				
				if (terrainHeightWhereWeAre < transform.position.y) {
					transform.position = new Vector3(transform.position.x,terrainHeightWhereWeAre,transform.position.z);
				}
				anim.Play ("falling");
				Debug.Log ("Fall now");
			}


		} 
	}

	void constrain(){
		if (transform.position.y <= 1) {
			transform.position = new Vector3(transform.position.x,1,transform.position.z);
			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;
			
			
			anim.Play("hitTheFloor");
			
		}
	}
	void pushBack(){
		flyMovement.enabled = false;
		for (int i=0; i<100; i++) {
			Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x,desiredXAngle,Time.deltaTime),
			                 transform.eulerAngles.y,
			                 Mathf.Lerp(transform.eulerAngles.z,desiredZAngle,Time.deltaTime));
		}
	}
}
