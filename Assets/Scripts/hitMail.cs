using UnityEngine;
using System.Collections;

public class hitMail : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}
}
