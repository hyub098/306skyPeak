using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour {
	public Text healtText;
    public bool testing;

//	public AudioClip gameoverSound;
//	public AudioClip hitSound;
//	private AudioSource source;


	public Image damageImg;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	bool damaged;


	public int life;
    private int counter = 0;

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
            counter++;
            //			source.clip = hitSound;
            //			source.Play ();

            string dir = System.IO.Directory.GetCurrentDirectory().ToString();
            string filename = dir + "\\lifelog.txt";
            if (testing)
            {
                using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(@filename, true))
                {

                    file.WriteLine("Expected outcome: life " + (3 - counter).ToString()
                        + " should be equal to " + life.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));

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

		return life;
	}


}
