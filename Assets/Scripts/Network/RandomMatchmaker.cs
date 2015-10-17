using UnityEngine;

public class RandomMatchmaker : Photon.PunBehaviour
{
	// Use this for initialization
	public string playerPrefabName="OnlineOwl";
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();

	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}

	void OnJoinedRoom(){

		Vector3 location = new Vector3 (-80f,98f,112f);
		GameObject bird = PhotonNetwork.Instantiate(this.playerPrefabName, location, Quaternion.identity, 0);
		MoveMent controller = bird.GetComponent<MoveMent>();
		// Enable the camera

		controller.isControllable = true;

//		CameraScript camera = bird.GetComponentInChildren<CameraScript> ();
//
//		camera.isMine = true;
		Transform playerCam = bird.transform.Find ("Camera");
		playerCam.gameObject.SetActive ( true);
	}
}
