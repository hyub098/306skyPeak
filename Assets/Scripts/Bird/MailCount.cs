using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MailCount : MonoBehaviour {
	public int mailCount;
	public Text mailText;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mailCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		mailText.text =  ("Mail:" + mailCount);
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Mail")) {
			other.gameObject.SetActive (false);
			Debug.Log (" Got Mail");
			mailCount++;
		
		}
	}
}
