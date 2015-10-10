using UnityEngine;

public class RandomMatchmaker : Photon.PunBehaviour
{
	// Use this for initialization
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

		GameObject monster = PhotonNetwork.Instantiate("GREAT_HORNED_OWL 1", Vector3.zero, Quaternion.identity, 0);
		moveMent controller = monster.GetComponent<moveMent>();
		controller.isControllable = true;
		//CharacterCamera camera = monster.GetComponent<CharacterCamera>();
		//camera.enabled = true;
	}
}
