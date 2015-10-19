using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour
{
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private bool isFinish;
	// Update is called once per frame
	void Update()
	{
		//Update other player's current location
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp (transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		} 
			
	}

	void OnGUI(){
		//If game is finished by other player,display "you lost" screen
		if (isFinish) {
			GUILayout.BeginArea (new Rect ((Screen.width - 500) / 2, (Screen.height - 300) / 2, 500, 300));
			GUILayout.BeginHorizontal ();
			GUI.skin.label.fontSize = 60;
			GUILayout.Label ("", GUILayout.Width (150));
			GUILayout.Label ("You lost!", GUILayout.Width (700));
			GUILayout.EndHorizontal ();
			GUILayout.Space (100);
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("", GUILayout.Width (150));
			GUI.skin.button.fontSize = 20;
			//button to go back to map
			if (GUILayout.Button ("Exit", GUILayout.Width (150))) {
				PhotonNetwork.LeaveRoom ();
				Application.LoadLevel (Application.loadedLevel);
				Application.LoadLevel (1);
			}
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			//send my state
			MoveMent myC = GetComponent<MoveMent>();
			stream.SendNext((int)myC._characterState);
			stream.SendNext((bool)myC.isFinish);
		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			MoveMent myC = GetComponent<MoveMent>();
			//receive network player's state
			myC._characterState = (BirdState)stream.ReceiveNext();
			isFinish = (bool)stream.ReceiveNext();
			//If the game is finished,stop the game
			if(isFinish){
				Time.timeScale = 0f; 
			}
		}
	}
}