﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailCount : MonoBehaviour {
	public int mailCount;
	public Text mailText;
	public Text gold;
	public int goldCount;
	public  Canvas Congratulations;
	private float time;
	private float winTime;
	private bool isSaved;
	public Text achieveText;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
		Congratulations.enabled = false;
		isSaved = false;
		achieveText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		mailText.text =  ("Mail:" + mailCount);
		gold.text = ("Gold: " + goldCount);

		time = time + (Time.deltaTime) * 1 ;
		if (goldCount == 300) {
			
			if(!isSaved){
				winTime = time;
				isSaved=true;
			}
			Debug.Log(time-winTime);
			Congratulations.enabled=true;

			if(time - winTime > 3){
				Application.LoadLevel("map");
			}

			if(time < 60){
				//achievement
				achieveText.enabled = true;

			}
			
		}
	
	}

	void OnTriggerEnter(Collider other){

		// If the player collide withe the mail box, increase the gold according to the number of mails
		if (other.gameObject.CompareTag ("Mail box")) {
			Debug.Log ("Deliver");
			goldCount=goldCount+mailCount*100;
			mailCount=0;


		}

		// If the player hit the mail
		if (other.gameObject.CompareTag ("Mail")) {
			// Player can only carry 3 mails at a time
			if(mailCount<3){
			other.gameObject.SetActive (false);
			Debug.Log (" Got Mail");
			mailCount++;
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
