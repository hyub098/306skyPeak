using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
    public GameObject owl;
	public GameObject axe;
	private GameObject axeClone;
    private float speed = 20;
    private Vector3 location;
	private bool destroy = true;

    public AudioClip throwSound;
    private AudioSource source;


    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        

		//get the owl location to aim at
		location = owl.transform.position;


		//if no active axe created, create one
		if (destroy) {
			axeClone = createAxe ();
		}


		//if there is active axe, throw it
		if (!destroy) {
			if(axeClone == null){
				destroy = true;
			}else{
				shootAxe (axeClone);
			}
		}

    }



	GameObject createAxe(){

		//Create Axe as game object
		GameObject instantiatedProjectile = Instantiate(axe, transform.position, transform.rotation) as GameObject;

		//aim at owl
		instantiatedProjectile.transform.LookAt (location);
		destroy = false;
		return instantiatedProjectile;

	}

	void shootAxe(GameObject axe){

		//play sound
        source.clip = throwSound;
        source.Play();

		//throw axe
        axe.transform.position += axe.transform.forward * Time.deltaTime * 10.0f;
		axe.transform.Rotate (0,0,1000);



		//Destroy the axe after 10 sec
		Destroy(axe, 10);

	}


}
