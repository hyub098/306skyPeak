using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
	private float currentSpd;
	private Vector3 moveDistance;
	private Rigidbody rb;
	private Animation anim;
	private int count=0;
	public float maxSpd;
	private int count2 = 0;

	void Start () {

		Debug.Log ("plane pilot script added to: " + gameObject.name);
		moveDistance = new Vector3(0,0,0);
		currentSpd = 0;
		anim = GetComponent<Animation> ();
		rb = GetComponent<Rigidbody> ();
	}

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        Vector3 syncVelocity = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = GetComponent<Rigidbody>().position;
            stream.Serialize(ref syncPosition);

            syncPosition = GetComponent<Rigidbody>().velocity;
            stream.Serialize(ref syncVelocity);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            stream.Serialize(ref syncVelocity);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = GetComponent<Rigidbody>().position;
        }
    }

    void Awake()
    {
        lastSynchronizationTime = Time.time;
    }

    void Update()
    {
        if (GetComponent<NetworkView>().isMine)
        {
			move();
            InputColorChange();
        }
        else
        {
            SyncedMovement();
        }
    }


    private void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * speed * Time.deltaTime);
    }


	void move(){
		//Get input from both axis
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		
		
		//Speed up with space
		if (Input.GetKey("space")) {
			
			//Increase speed slowly to max
			currentSpd = Mathf.Lerp(currentSpd, maxSpd, Time.deltaTime);
			Debug.Log("CurrentSpd:" + currentSpd);
			
			//move the plane
			moveDistance = transform.forward * Time.deltaTime * currentSpd;
			transform.position += moveDistance;
			
			//remove rigid body force
			rb.velocity = Vector3.zero;
			rb.useGravity = false;
			
			
			//animation clip
			if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 61) {
				anim.Play("glideNormal");
				count2++;
				if (count2 == 300)
				{
					count2 = 0;
				}
			} else if (transform.eulerAngles.x > 299 && transform.eulerAngles.x < 361) {
				anim.Play("flyNormal");
				count++;
				if (count == 100)
				{
					count = 0;
				}
			}
		} else {
			
			//Re-adjust owl if space is not pressed
			currentSpd = 0;

				//Calculate angle to re-adjust
				float desiredZAngle = 0;
				float desiredXAngle = 330;
				if(transform.eulerAngles.z > 180){desiredZAngle = 360;} else {desiredZAngle = 0;}
				if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 60){desiredXAngle = -30;}
				if(transform.position.y > 2){
					anim.Play("idleFloor2");

				
				//turn on gravity to allow falling
				rb.useGravity = true;
				
				//change rotation of owl
				transform.rotation = Quaternion.Euler(Mathf.Lerp(transform.eulerAngles.x,desiredXAngle,Time.deltaTime),
				                                      transform.eulerAngles.y,
				                                      Mathf.Lerp(transform.eulerAngles.z,desiredZAngle,Time.deltaTime));
				
			}
		}
		
		//Change rotation of owl base on user input
			//rotate the plane from input
			transform.Rotate (-v,h*1.2f, -h*0.6f);

		
		
	}


    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;

        GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }


    private void InputColorChange()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    [PunRPC] void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);

        if (GetComponent<NetworkView>().isMine)
            GetComponent<NetworkView>().RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
    }
}
