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
			StartCoroutine(flash());
		} else {
			invincible = false;
			skinnedMeshRenderer.material.color = Color.white;
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

			if(!invincible){
				invincible = true;
				hitTime = time;
				Debug.Log(hitTime);
				life = lifeManager.subtractLife ();
//				flash();
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
	IEnumerator flash(){
		invincible = true;
		for(int i = 0; i<2;i++){

				skinnedMeshRenderer.material.color = Color.clear;
			yield return new WaitForSeconds(.1f);

				skinnedMeshRenderer.material.color = Color.white;
			yield return new WaitForSeconds(.1f);
		}

	}


}
