using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
    public GameObject owl;
	public GameObject axe;
	private GameObject axeClone;
    private float speed = 20;
    private Vector3 location;
	private bool destroy = true;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
		location = owl.transform.position;
//		location =  Vector3.Scale(owl.transform.position, new Vector3(10,10,10));

		if (destroy) {
			axeClone = createAxe ();
		}
					
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

		instantiatedProjectile.transform.LookAt (location);
		destroy = false;
		return instantiatedProjectile;

	}

	void shootAxe(GameObject axe){

	//	axe.transform.position = Vector3.Lerp(axe.transform.position, location, 0.001f);
		axe.transform.position += axe.transform.forward * Time.deltaTime * 10.0f;
		axe.transform.Rotate (0,0,1000);



		//Destroy the axe 
		Destroy(axe, 10);

	}


}
