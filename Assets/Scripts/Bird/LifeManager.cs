using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour {
	public Text healtText;
    public bool testing;




	public Image damageImg;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	bool damaged;


	public int life;
    private int counter = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		healtText.text = "life:" + life;

		//flash damage color
		if (damaged) {
			//flash  to red
			damageImg.color = flashColour;
		} else {

			//back to normal
			damageImg.color = Color.Lerp (damageImg.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	//method being called by collision
	public int subtractLife(){
		damaged = true;

		//check the life
		if (life > 0) {
			life--;
            counter++;
            
            
// This section is uncommented when we are running our unit test to test the life system


//            string dir = System.IO.Directory.GetCurrentDirectory().ToString();
//            string filename = dir + "\\lifelog.txt";
//            if (testing)
//            {
//                using (System.IO.StreamWriter file =
//               new System.IO.StreamWriter(@filename, true))
//                {
//
//                    file.WriteLine("Expected outcome: life " + (3 - counter).ToString()
//                        + " should be equal to " + life.ToString() + " at time " + System.DateTime.Now.ToString("h:mm:ss tt"));
//
//                    file.WriteLine("------------------------------");
//                    file.WriteLine();
//                }
//            }
//            else
//            {
//                if (System.IO.File.Exists(@filename))
//                    System.IO.File.Delete(@filename);
//            }
		}

		return life;
	}


}
