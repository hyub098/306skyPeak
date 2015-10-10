using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collision : MonoBehaviour {
	private Rigidbody rb;
	private Animation anim;
	private bool collision;

	private FlyMovement flyMovement;
	private Vector3 moveBackPosition;
	private float time;
	public Canvas gameOver;
    public Image achievement_Pressure, achievement_Wipeout;
    private bool ispause;
	private float deadTime;
	private bool isSaved;

	public LifeManager lifeManager;
    
    private int count = 0;


    void Start()
    {

        Debug.Log("Collision script added to: " + gameObject.name);

		collision = false;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
		flyMovement = GetComponent<FlyMovement> ();
		gameOver.enabled = false;
        achievement_Pressure.enabled = false;
        achievement_Wipeout.enabled = false;
        ispause = false;
		isSaved = false;
		lifeManager = new LifeManager ();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (flyMovement.enabled == false)
        {

            if (time > 5)
            {
                flyMovement.enabled = true;
                Debug.Log("enabled");
                time = 0;

            }
            else
            {
                Debug.Log("moveBackPosition" + moveBackPosition);
                Debug.Log("current:" + transform.position);
                pushBack();
            }
            time = time + (Time.deltaTime) * 1;
        }

        if (ispause)
        {
            Time.timeScale = 0f;
        }

        if (life < 1)
        {

            if (!isSaved)
            {
                deadTime = time;
                isSaved = true;
            }
            Debug.Log(time - deadTime);

            if (time - deadTime > 3)
            {

                //	Application.LoadLevel(Application.loadedLevel);

            }
            if (count == 0)
            {
                gameOver.enabled = true;
                count = count + 1;
               

                //If time is less than 10 seconds give the wipeout 
                if (time <= 10)
                {
                    achievement_Wipeout.enabled = true;
                }
            }

        }

    }


    //collision detection
    void OnCollisionEnter(UnityEngine.Collision collision)
    {

		if (!collision.gameObject.CompareTag ("Mail box")) {
			int life = lifeManager.subtractLife();


			
			if (life < 1) {
				flyMovement.enabled = false;
				rb.useGravity = true;
				anim.Play ("falling");
				//if (count == 0)
				//{
				//  count = count + 1;
				//source.clip = gameoverSound;
				//source.Play();
				//Debug.Log("game over");
				//}
				gameOver.enabled = true;
				
			}
		}


    }


    void constrain()
    {
        if (transform.position.y <= 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            //remove rigid body force
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            anim.Play("hitTheFloor");

        }
    }
    //help method for pushing back the owl
    void pushBack()
    {
        transform.position = transform.position - transform.forward * Time.deltaTime;
    }
    //help method for comparing two Vector3 objects.
    public bool V3Equal(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.01;
    }


}
