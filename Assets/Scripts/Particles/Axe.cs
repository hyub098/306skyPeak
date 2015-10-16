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


	public GameObject createAxe(){

		//Create Axe as game object
		GameObject instantiatedProjectile = Instantiate(axe, transform.position, transform.rotation) as GameObject;

		instantiatedProjectile.transform.LookAt (location);
		destroy = false;
		return instantiatedProjectile;

	}

	void shootAxe(GameObject axe){

		// instantiatedProjectile.transform.Rotate(-90f, 0.0f, 0.0f);
		axe.transform.position = Vector3.Lerp(axe.transform.position, location, 0.1f);
	
		//Destroy the arrow 
		Destroy(axe, 3);

	}

}
