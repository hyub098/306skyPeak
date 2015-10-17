using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour {
	public Text healtText;

//	public AudioClip gameoverSound;
//	public AudioClip hitSound;
//	private AudioSource source;


	public Image damageImg;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	bool damaged;


	public int life;

	// Use this for initialization
	void Start () {

//		source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

		healtText.text = "life:" + life;

		//flash damage color
		if (damaged) {
			damageImg.color = flashColour;
		} else {
			damageImg.color = Color.Lerp (damageImg.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public int subtractLife(){
		damaged = true;

		//check the life
		if (life > 0) {
			life--;
//			source.clip = hitSound;
//			source.Play ();



			  using (System.IO.StreamWriter file =
			   new System.IO.StreamWriter(@"C:\Users\Public\skypeak_log.txt", true))
			{
			  file.WriteLine("Expected outcome: life " + (life + 1).ToString() + " -> " + "collision" + "-->" + life.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));
			file.WriteLine("assert: life " + (life + 1).ToString() + " -> " + "collision" + "-->" + life.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));
			}
			
		}

		return life;
	}


}
