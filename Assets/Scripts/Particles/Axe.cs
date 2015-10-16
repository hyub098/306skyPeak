using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
    public GameObject owl;
    public GameObject axe;
    private float speed = 20;
    private Vector3 location;
    //private int count = 0;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (count > 100)
        //{
            location = owl.transform.position;
            GameObject instantiatedProjectile = Instantiate(axe, transform.position, transform.rotation) as GameObject;
            instantiatedProjectile.transform.Rotate(-90f, 0.0f, 0.0f);
        instantiatedProjectile.transform.position = Vector3.Lerp(instantiatedProjectile.transform.position, location, 0.05f);
        //Destroy the arrow after 10 seconds
        Destroy(instantiatedProjectile, 10);
          //  count++;
        //}
        //count = 0;
    }
}
