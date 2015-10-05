using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailCount : MonoBehaviour {
	public int mailCount;
	public Text mailText;
	public Text gold;
	public int goldCount;
	public  Canvas Congratulations;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
		Congratulations.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		mailText.text =  ("Mail:" + mailCount);
		gold.text = ("Gold: " + goldCount);
	
	}

	void OnTriggerEnter(Collider other){

		// If the player collide withe the mail box, increase the gold according to the number of mails
		if (other.gameObject.CompareTag ("Mail box")) {
			Debug.Log ("Deliver");
			goldCount=goldCount+mailCount*100;
			mailCount=0;

			// If player get all 3 mails, end the game
			if(goldCount==300){
			Congratulations.enabled=true;
				Time.timeScale = 0f;
			}

		}

		// If the player hit the mail
		if (other.gameObject.CompareTag ("Mail")) {
			// Player can only carry 3 mails at a time
			if(mailCount<3){
			other.gameObject.SetActive (false);
			Debug.Log (" Got Mail");
			mailCount++;
			}
		}
	}
}
