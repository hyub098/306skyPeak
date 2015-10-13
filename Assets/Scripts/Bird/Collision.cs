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
//    public Image achievement_Pressure, achievement_Wipeout;
    private bool ispause;
	private float deadTime;
	private bool isSaved;

	private LifeManager lifeManager;
    
    private int count = 0;
	private int life;
	private bool invincible;
	private float hitTime;



	private SkinnedMeshRenderer skinnedMeshRenderer; 
	private Texture normTexture;

    void Start()
    {

        Debug.Log("Collision script added to: " + gameObject.name);

		collision = false;
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animation> ();
		flyMovement = GetComponent<FlyMovement> ();
		gameOver.enabled = false;

		skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();  
		skinnedMeshRenderer.material.mainTexture = normTexture;
//        achievement_Pressure.enabled = false;
//        achievement_Wipeout.enabled = false;
        ispause = false;
		isSaved = false;
		lifeManager = GetComponent<LifeManager> ();
		invincible = false;
		hitTime = 0;
		life = 3;
       
    }

    // Update is called once per frame
    void Update()
    {
		time = time + (Time.deltaTime) * 1;



		if ((time - hitTime) < 5) {
			invincible = true;
		} else {
			invincible = false;
			Debug.Log ("false");
		}

        if (ispause)
        {
            Time.timeScale = 0f;
        }

//        if (life < 1)
//        {
//
//            if (!isSaved)
//            {
//                deadTime = time;
//                isSaved = true;
//            }
//            Debug.Log(time - deadTime);
//
//            if (time - deadTime > 3)
//            {
//
//                //	Application.LoadLevel(Application.loadedLevel);
//
//            }
//            if (count == 0)
//            {
//                gameOver.enabled = true;
//                count = count + 1;
//               
//
//                //If time is less than 10 seconds give the wipeout 
//                if (time <= 10)
//                {
//                    achievement_Wipeout.enabled = true;
//                }
//            }
//
//        }

    }


    //collision detection
    void OnCollisionEnter(UnityEngine.Collision collision)
    {


			if (!collision.gameObject.CompareTag ("Mail box")) {

			if(invincible == false){
				invincible = true;
				hitTime = time;
				Debug.Log(hitTime);
				life = lifeManager.subtractLife ();
			}


				
			
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

}
