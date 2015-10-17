using UnityEngine;
using System.Collections;

public class Axe2 : MonoBehaviour
{
    public GameObject owl;
    //public GameObject axe;
    private float speed = 20;
    private Vector3 location;
    private Vector3 axeLocation;
    private int c;
    //private int count = 0;
    // Use this for initialization
    void Start()
    {
        c = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (count > 100)
        //{
        if (c==1)
        {
            location = owl.transform.position;
            //axeLocation = new Vector3(0,0,0);
            //GameObject instantiatedProjectile = Instantiate(axe, transform.position, transform.rotation) as GameObject;
            transform.Rotate(1.0f, 3.0f, 2.0f);
            transform.position = Vector3.Lerp(transform.position, location, 0.05f);
            
            //transform.position = Vector3.Lerp(transform.position, axeLocation, 0.05f);
            //Destroy the arrow after 10 seconds
            //  count++;
            //}
            //count = 0;
            //c = 2;
        }
    }

 
}

