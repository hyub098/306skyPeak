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

		//intialize all variables
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



		//within the time limit, owl is invincible, and flash to notice player
		if ((time - hitTime) < 5) {
			//flash
			invincible = true;
			StartCoroutine(flash());
		} else {
			//stop flashing, back to normal
			invincible = false;
			skinnedMeshRenderer.material.color = Color.white;
		}

		//pause game
        if (ispause)
        {
            Time.timeScale = 0f;
        }

		//check if owl is dead 
        checkDead();

    }
	

    //collision detection
    void OnCollisionEnter(UnityEngine.Collision collision)
    {


			if (!collision.gameObject.CompareTag ("Mailbox")) {
            if (!invincible){

                // when a collision happens, a collision sound is played.
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
			//enable gravity and disable user control
			flyMovement.enabled = false;
			rb.useGravity = true;

            //when the player loses all three lifes, the game-over sound is played.
            source.clip = gameOverSound;
            source.Play();

			//play falling animation
            anim.Play ("falling");
			gameOver.enabled = true;
			Time.timeScale = 0f; //Stop the game

			//Check if the time is less than 30 seconds, give achievement
			if (time <= 30)
			{
				achievement_Wipeout.enabled = true;
				wipeout = true;
			}
			
			//Check if the owl is carry more than 3 pieces of mail, give achievement
			mailCount = GetComponent<MailCount>();
			carryingMail = mailCount.returnMail();
			if (carryingMail >= 3)
			{
				achievement_Pressure.enabled = true;
				pressure = true;
			}
			
			
		}
	}

	//public function to check current life
    public int returnLife()
    {
        return life;
    }

	//flash the owl to notice player
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
