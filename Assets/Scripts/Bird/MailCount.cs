using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailCount : MonoBehaviour {
	public int mailCount;
	public Text mailText;
	public  Canvas Congratulations;
	private float time;
    public Image achievement_Mountain, achievement_Perfect, achievement_City, achievement_CloseOne, achievement_Park, achievement_Fast;

    public AudioClip getMailSound;
    public AudioClip postMailSound;
    private AudioSource source;

    private Rigidbody rb;
	private int level;



	// Use this for initialization
	void Start () {
		Debug.Log ("script added:" );
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
		Congratulations.enabled = false;
        achievement_Mountain.enabled = false;
        achievement_Perfect.enabled = false;
        achievement_City.enabled = false;
        achievement_CloseOne.enabled = false;
        achievement_Park.enabled = false;
        achievement_Fast.enabled = false;
        //source = GetComponent<AudioSource>();
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
		if (other.gameObject.CompareTag ("Mail box")) {
			Debug.Log ("Deliver");
			checkWin ();
			//mailCount=0;
            //source.clip = postMailSound;
            //source.Play();

        }

		// If the player hit the mail
		if (other.gameObject.CompareTag ("Mail")) {
			// Player can only carry 3 mails at a time
			if(mailCount<10){
			other.gameObject.SetActive (false);


			Debug.Log (" Got Mail");
			mailCount++;

			//play audio
            //source.clip = getMailSound;
            //source.Play();

			//debug file
            using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(@"C:\Users\Public\skypeak_log.txt", true))
                {
                    file.WriteLine("Expected outcome: mailcount " + (mailCount - 1).ToString() + " -> " + "collision with mail" + "-->" + mailCount.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));
                    file.WriteLine("assert: mailcount " + (mailCount - 1).ToString() + " -> " + "collision with mail" + "-->" + mailCount.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));
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
                //Achievement for beating park in under a minute
                if (time < 60)
                {

                    achievement_Park.enabled = true;

                }

            }
        }
        else if (level == 2)
        {
            if (mailCount >= 5)
            {
                Congratulations.enabled = true;
                //Achievement for beating mountain in under a minute
                if (time < 120)
                {

                    achievement_Mountain.enabled = true;

                }
            }
        }
        else if (level == 3)
        {
            if (mailCount >= 10)
            {
                Congratulations.enabled = true;
                //Achievement for beating city in under 3 minutes
                if (time < 180)
                {

                    achievement_City.enabled = true;

                }
            }
        }
    }
}