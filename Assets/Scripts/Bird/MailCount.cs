using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailCount : MonoBehaviour {
	public int mailCount;
	public Text mailText;
	public  Canvas Congratulations;
	private float time;
	public Text achieveText;

    public AudioClip getMailSound;
    public AudioClip postMailSound;
    private AudioSource source;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
		Congratulations.enabled = false;
		achieveText.enabled = false;
        source = GetComponent<AudioSource>();
    }

	
	// Update is called once per frame
	void Update () {

		//update mail number
		mailText.text =  ("Mail:" + mailCount);

		time = time + (Time.deltaTime) * 1 ;
	
			

			Congratulations.enabled=true;

			if(time < 60){
				//achievement
				achieveText.enabled = true;

			}
			

	
	}

	void OnTriggerEnter(Collider other){

		// If the player collide withe the mail box, increase the gold according to the number of mails
		if (other.gameObject.CompareTag ("Mail box")) {
			Debug.Log ("Deliver");
			mailCount=0;
            source.clip = postMailSound;
            source.Play();

        }

		// If the player hit the mail
		if (other.gameObject.CompareTag ("Mail")) {
			// Player can only carry 3 mails at a time
			if(mailCount<10){
			other.gameObject.SetActive (false);


			Debug.Log (" Got Mail");
			mailCount++;

			//play audio
            source.clip = getMailSound;
            source.Play();

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
}
