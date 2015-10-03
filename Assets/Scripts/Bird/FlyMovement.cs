using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyMovement : MonoBehaviour {
	
	public float speed;
//	public float moveSpd;
	
//	public Text winText;
//	private Rigidbodyrb;

	private int count;

	private float rotationX;
	private float rotationZ;

	Animator anim;
	Animation anima;
	private float flyCount;

    int incrementTime = 1;
    float incrementBy = 1;
    float counter = 0;
    int minute = 0;
    int second = 0;
    float time = 0;

//    public string timerFormatted;
//    public Text timerText;



    // Use this for initialization
    void Start () {
		Debug.Log ("plane pilot script added to: " + gameObject.name);
		anim = GetComponent<Animator> ();
		anima = GetComponent<Animation> ();
        //		rb = this.GetComponent<Rigidbody> ();
        //		rb.velocity = Vector3.ClampMagnitude (rb.velocity, 0f);


     //   SetTimerText();

        //		SetCountText();
    }

    // Update is called once per frame
    void Update () {


		animating();
//        minute = (int)counter / 60;
//        second = (int)counter % 60;
//        time += Time.deltaTime;
//        while (time > incrementTime)
//        {
//            time -= incrementTime;
//            counter += incrementBy;
//        }
//        timerFormatted = string.Format("{0:00}:{1:00}", minute, second);
//        SetTimerText();

        //camera position adjust
        Vector3 moveCamtTo = transform.position - transform.forward * 5.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamtTo * (1.0f - bias);
		
		Camera.main.transform.LookAt (transform.position + transform.forward * 1.0f);

		//Vector3 currentAngle = transform.rotation.eulerAngles;

		//move the plane
		transform.position += transform.forward * Time.deltaTime * speed;
	
		if (Rotation ()) {
			//rotate the plane from input
			transform.Rotate (-Input.GetAxis("Vertical"),0.0f, -Input.GetAxis("Horizontal"));
		}

		//speed -= transform.forward.y * Time.deltaTime *  2.0f;
		
	}

	void animating(){
		flyCount++;
		if (flyCount > 150) {
//			anim.SetBool ("Fall", true);
			anima.Play("falling");
		}
	}

//	/**
//	 * If collide with objects with tag pick up
//	 * 
//	 */ 
//	void OnTriggerEnter(Collider other){
//		
//		if ( other.gameObject.CompareTag("Pick Up")){
//			other.gameObject.SetActive(false);
//			count++;
//			SetCountText();
//		}
//		
//	}
//
//	//Set Text to UI
//	void SetCountText()
//		
//	{
//		countText.text = "Count: " + count.ToString ();
//		
//	}


	/**
	 * Limit rotation to 45 degrees up/down, 50 degreesleft/right
	 * 
	 * Note: Camera shakes when rotation is re-adjusted. Looking for better way to constraint rotation
	 * 
	 */
	bool Rotation()
	{
		bool rotate = true;

		if (transform.eulerAngles.x > 45f && transform.eulerAngles.x < 315f){ 

			rotate = false;

			if(transform.eulerAngles.x < 100){
				transform.eulerAngles = new Vector3(45,transform.eulerAngles.y, transform.eulerAngles.z);
			}
			else{
				transform.eulerAngles = new Vector3(315,transform.eulerAngles.y, transform.eulerAngles.z);
			}

		}

//		if (50f < transform.eulerAngles.z  && transform.eulerAngles.z < 310f){ 
//			rotate = false;
//
//			if(transform.eulerAngles.z < 100){
//				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,45);
//
//			}else{
//				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,310);
//
//			}
//			
//		}

/// Test

		return rotate;
	}
//
//    void SetTimerText()
//    {
//        timerText.text = "Time: " + timerFormatted;
//    }

}
