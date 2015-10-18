using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour
{
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private bool isFinish;
	private bool otherDoor;
	// Update is called once per frame
	void Update()
	{
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp (transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		} 
			//gameObject.GetComponent<MoveMent>().isFinish=isFinish;
			
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);

			MoveMent myC = GetComponent<MoveMent>();
			stream.SendNext((int)myC._characterState);
			stream.SendNext((bool)myC.isFinish);

			DoorScript doorScript = GetComponent<DoorScript>();
			stream.SendNext((bool)doorScript.myDoor);

			
		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();

			MoveMent myC = GetComponent<MoveMent>();
			myC._characterState = (BirdState)stream.ReceiveNext();
			isFinish = (bool)stream.ReceiveNext();
			if(isFinish){
				Time.timeScale = 0f; //Stops the game
			}

			DoorScript doorScript = GetComponent<DoorScript>();
			otherDoor = (bool) stream.ReceiveNext();
			doorScript.otherDoor=otherDoor;

		}
	}
}