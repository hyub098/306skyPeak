using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//Class to count the mail as it is collected
public class MailCount : MonoBehaviour {

    public bool testing ;
    
    public int mailCount;
	public Text mailText;
	public  Canvas Congratulations;
	private float time;
    public Image achievement_timeMountain, achievement_timeCity, achievement_city3Lives, achievement_CloseOne, achievement_timePark, achievement_mountain3Lives, achievement_park3Lives;

	public static bool timePark;
	public static bool timeMountain;
	public static bool timeCity;
	
	public static bool closeOne;

	public static bool city3Lives;
	public static bool mountain3Live;
	public static bool park3Lives;

    public AudioClip getMailSound;
    public AudioClip postMailSound;
    public AudioClip winSound;
    private AudioSource source;

    private Rigidbody rb;
	private int level;
    private int life;
    private Collision collision;
    private int firstOnMailBox;
    private int counter =0;




    // Use this for initialization
    void Start () {
        collision = GetComponent<Collision>();
        Debug.Log ("script added:" );
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
		Congratulations.enabled = false;
        achievement_timeMountain.enabled = false;
        achievement_timeCity.enabled = false;
        achievement_city3Lives.enabled = false;
        achievement_CloseOne.enabled = false;
        achievement_timePark.enabled = false;
        achievement_mountain3Lives.enabled = false;
        achievement_park3Lives.enabled = false;

		timePark = false;
		timeMountain = false;
		timeCity = false;
		
		closeOne = false;
		
		city3Lives = false;
		mountain3Live = false;
		park3Lives = false;

        source = GetComponent<AudioSource>();
        firstOnMailBox = 0;
        level = getLevel();

       
    }


    // Update is called once per frame
    void Update () {

		//update mail number
		mailText.text =  ("Mail:" + mailCount);

		time = time + (Time.deltaTime) * 1 ;

	}

	void OnTriggerEnter(Collider other){

		// If the player collide withe the mail box, increase the gold according to the number of mails
		if (other.gameObject.CompareTag ("Mailbox")) {
			Debug.Log ("Deliver");
			checkWin ();

        }

		// If the player hit the mail
		if (other.gameObject.CompareTag ("Mail")) {

            //incremenet counter 
            counter++;

          
            if (mailCount < 10) {
                other.gameObject.SetActive(false);


                Debug.Log(" Got Mail");
                mailCount++;

                //play audio
                source.clip = getMailSound;
                source.Play();

                string dir = System.IO.Directory.GetCurrentDirectory().ToString();
                string filename = dir + "\\maillog.txt";

                if (testing) { 
                    //debug file
                   
                using (System.IO.StreamWriter file =
                   new System.IO.StreamWriter(@filename, true))
                {
                    //file.WriteLine("filename: "+filename);
                    file.WriteLine("Expected outcome: mailcount " + (counter).ToString() +
                        " should be equal to " + mailCount.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));

                    file.WriteLine("------------------------------");
                    file.WriteLine();

                }
                }
                else
                {
                    if (System.IO.File.Exists(@filename))
                        System.IO.File.Delete(@filename);
                }

            }
        }
	}

	int getLevel(){
		int level = 0;
		if(Application.loadedLevelName.Equals("Park")){
			level = 1;
		}else if(Application.loadedLevelName.Equals("mountain1")){
			level = 2;
		}else if(Application.loadedLevelName.Equals("city")){
			level = 3;
		}
		return level;
	}

    void checkWin()
    {
        Debug.Log("check win");
        if (level == 1)
        {
            if (mailCount >= 3)
            {
                Congratulations.enabled = true;
                source.clip = winSound;
                source.Play();
                Time.timeScale = 0f; //Stop the game
                //Achievement for beating park in under a minute
                if (time < 60)
                {

                    achievement_timePark.enabled = true;
					timePark = true;

                }

                //Achievement for beating park without losing a life
                life = collision.returnLife();
                if (life == 3)
                {
                    achievement_park3Lives.enabled = true;
					park3Lives = true;
                }

                //Achievement for winning with only one life left
                if (life == 1)
                {
                    achievement_CloseOne.enabled = true;
					closeOne = true;
                }

            }
            else
            {
                if (firstOnMailBox == 0)
                {

                    firstOnMailBox = 1;
                }
                else
                {
                    source.clip = postMailSound;
                    source.Play();
                }
            }
        }
        else if (level == 2)
        {
            if (mailCount >= 5)
            {
                Congratulations.enabled = true;
				Time.timeScale = 0f; //Stop the game
                //Achievement for beating mountain in under a minute
                if (time < 120)
                {

                    achievement_timeMountain.enabled = true;
					timeMountain = true;

                }

                //Achievement for beating mountain without losing a life
                life = collision.returnLife();
                if (life == 3)
                {
                    achievement_mountain3Lives.enabled = true;
					mountain3Live = true;
                }

                //Achievement for winning with only one life left
                if (life == 1)
                {
                    achievement_CloseOne.enabled = true;
					closeOne = true;
                }

            }
        }
        else if (level == 3)
        {
            if (mailCount >= 10)
            {
                Congratulations.enabled = true;
				Time.timeScale = 0f; //Stop the game
                //Achievement for beating city in under 3 minutes
                if (time < 180)
                {

                    achievement_timeCity.enabled = true;
					timeCity = true;

                }

                //Achievement for beating city without losing a life
                life = collision.returnLife();
                if (life == 3)
                {
                    achievement_city3Lives.enabled = true;
					city3Lives = true;
                }

                //Achievement for winning with only one life left
                if (life == 1)
                {
                    achievement_CloseOne.enabled = true;
					closeOne = true;
                }

            }
        }
    }


    public int returnMail()
    {
        return mailCount;
    }
}
