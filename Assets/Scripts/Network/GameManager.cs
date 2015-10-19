using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//prefab name, should be in Resource folder
	public string playerPrefabName = "OnlineOwl";
	public Camera camera;
	public Canvas start;
	public GameObject door;

	void OnJoinedRoom()
	{
		StartGame();
		PlayAnimation doorScript=door.GetComponent<PlayAnimation> ();
		doorScript.openDoor = true;
		doorScript.isOpen = false;
		Time.timeScale = 1.0f;
	}
	
	IEnumerator OnLeftRoom()
	{
		//reset everything
		//Wait untill Photon is properly disconnected (empty room, and connected back to main server)
		while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
			yield return 0;
		
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1.0f;

		
	}
	
	void StartGame()
	{
		// Spawn our local player
		camera.enabled = false;
		Vector3 location = new Vector3 (-80f,98f,118f);
		GameObject bird = PhotonNetwork.Instantiate (this.playerPrefabName, location, Quaternion.identity, 0);
		bird.gameObject.transform.Rotate (0.0f, 90.0f, 0.0f);
		MoveMent controller = bird.GetComponent<MoveMent>();
		// Enable the camera
		controller.isControllable = true;
		Transform playerCam = bird.transform.Find ("Camera");
		playerCam.gameObject.SetActive ( true);
		start.enabled = true;

	}
	
	void OnGUI()
	{
		if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room
		GUI.skin.button.fontSize = 13;
		if (GUILayout.Button("Leave Room"))
		{
			PhotonNetwork.LeaveRoom();
			start.enabled=false;
			Time.timeScale = 1.0f;
		}
	}
	
	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}    
}
