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

	public static bool pressure;
	public static bool wipeout;

    private bool ispause;
	private float deadTime;
	private bool isSaved;

	private LifeManager lifeManager;
    private MailCount mailCount;
    
    private int count = 0;
	private int life;
	private bool invincible;
	private float hitTime;
    private int carryingMail;

    public AudioClip collisionSound;
    public AudioClip gameOverSound;
    private AudioSource source;

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
        achievement_Pressure.enabled = false;
        achievement_Wipeout.enabled = false;
        ispause = false;
		isSaved = false;
		lifeManager = GetComponent<LifeManager> ();
		invincible = false;

		pressure = false;
		wipeout = false; 

		hitTime = 0;
		life = 3;
        source = GetComponent<AudioSource>();

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

		checkDead();

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


			if (!collision.gameObject.CompareTag ("Mailbox")) {
            if (!invincible){
                source.clip = collisionSound;
                source.Play();
                //stop it from further damage
                invincible = true;
				//record hit time
				hitTime = time;

				//Change life
				life = lifeManager.subtractLife ();
                //flash();
            }



				
			
				
        }



    }

	void checkDead(){
		if (life < 1) {
			flyMovement.enabled = false;
			rb.useGravity = true;
            source.clip = gameOverSound;
            source.Play();
            anim.Play ("falling");
			//if (count == 0)
			//{
			//  count = count + 1;
			//source.clip = gameoverSound;
			//source.Play();
			//Debug.Log("game over");
			//}
			gameOver.enabled = true;
			Time.timeScale = 0f; //Stop the game
			
			
			//Check for time and 3 mail achievements
			
			//Check if the time is less than 20 seconds
			if (time <= 30)
			{
				achievement_Wipeout.enabled = true;
				wipeout = true;
			}
			
			//Check if the owl is carry more than 3 pieces of mail
			mailCount = GetComponent<MailCount>();
			carryingMail = mailCount.returnMail();
			if (carryingMail >= 3)
			{
				achievement_Pressure.enabled = true;
				pressure = true;
			}
			
			
		}
	}

    public int returnLife()
    {
        return life;
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
