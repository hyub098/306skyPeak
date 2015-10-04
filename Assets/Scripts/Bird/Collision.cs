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
	private Vector3 moveBackPosition;
	private float time;
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
		if (flyMovement.enabled == false) {

			if(time>5){
				flyMovement.enabled=true;
				Debug.Log ("enabled");
				time=0;

			}else{
				Debug.Log("moveBackPosition"+moveBackPosition);
				Debug.Log("current:"+transform.position);
				pushBack();
//				transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
//				                                      transform.eulerAngles.y,
//				                                      Mathf.Lerp(transform.eulerAngles.z,transform.eulerAngles.z+10,Time.deltaTime));

			}
			time = time + (Time.deltaTime) * 1 ;
		}

	}

	void OnTriggerEnter(Collider other){
		collision = true;



		if (other.gameObject.CompareTag ("Terrain")) {
			life--;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{
				Debug.Log("Point of contact: "+hit.point);
				Vector3 moveDistance = transform.forward * Time.deltaTime*200;
				Debug.Log(hit.point-moveDistance);
				flyMovement.enabled = false;
				moveBackPosition=transform.position-moveDistance;
				Debug.Log ("disabled");
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
		transform.position = transform.position - transform.forward * Time.deltaTime ;
	}
	public bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.01;
	}
}
