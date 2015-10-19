using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
* Tutorial is used for training scene to lead the learner to complete the basic flying skills
* and post mail skills.
*/
public class Tutorial : MonoBehaviour {

    public Text instruction;
    public Canvas congratulations;
    public Canvas congratulations2;
    public Image space;
    public Image up;
    public Image down;
    public Image left;
    public Image right;
    private int count;
    private int count2;
    private int count3;

    // Use this for initialization
    void Start() {
        count = 0;
        count2 = 0;
        count3 = 0;
        congratulations2.enabled = false;
        congratulations.enabled = false;
        space.enabled = false;
        up.enabled = false;
        down.enabled = false;
        left.enabled = false;
        right.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        // ask the learner to take off
        if (count == 200)
        {
            space.enabled = true;
            instruction.text = "Please use space to take off.";
            count2 = 1;
        }
        //ask the learner to fly up
        else if (Input.GetKey("space") && count2 == 1)
        {
            up.enabled = true;
            instruction.text = "Please use space with up key to fly up.";
            count2 = 2;
        }
        //ask the learner to fly down
        else if (Input.GetKey("up") && Input.GetKey("space") && count2 == 2)
        {
            up.enabled = false;
            down.enabled = true;
            instruction.text = "Please use space with down key to fly down.";
            count2 = 3;
        }
        //ask the learner to fly left
        else if (Input.GetKey("down") && Input.GetKey("space") && count2 == 3)
        {
            down.enabled = false;
            left.enabled = true;
            instruction.text = "Please use space with left key to fly left.";
            count2 = 4;
        }
        //ask the learner to fly right
        else if (Input.GetKey("left") && Input.GetKey("space") && count2 == 4)
        {
            left.enabled = false;
            right.enabled = true;
            instruction.text = "Please use space with right key to fly right.";
            count2 = 5;
        }
        //tell the learner that he/she has already complete the basic flying skills, and last for 2 seconds
        else if (Input.GetKey("right") && Input.GetKey("space") && count2 == 5)
        {
            right.enabled = false;
            instruction.text = "Congratulations! You've learnt all basic fly skills.";
            count2 = 6;
        }
        else if (count2 == 6 && count3 < 200)
        {
            space.enabled = false;
            congratulations.enabled = true;
            count3++;
            instruction.text = "Congratulations! You've learnt all basic fly skills.";
        }
        //ask the learner to collect a scroll
        else if (count3 >= 200 && count2 < 7)
        {
            congratulations.enabled = false;
            instruction.text = "Fly to a scroll and get it.";
        }
        //ask the learner to deliver a scroll
        else if (count2 == 7&& count3 >= 200)
        {
            congratulations.enabled = false;
            instruction.text = "Deliver the scroll to the mail box.";
        }
        //tell the learner that he/she has already complete the post mail skills
        else if (count2 == 8&& count3 >= 200)
        {
            congratulations.enabled = false;
            congratulations2.enabled = true;
            instruction.text = "Congratulations. Qualified post carrier!";
        }
        count++;
    }

    //check the collisions
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // If the player collide with the mail box
        if (collision.gameObject.CompareTag("Mailbox"))
        {
            count2 = 8;
            //Debug.Log("Finished");
        }

        Debug.Log("Finished");

        // If the player hit the mail
        if (collision.gameObject.CompareTag("Mail"))
        {
            collision.gameObject.SetActive(false);
            count2 = 7;
        }
    }
}
