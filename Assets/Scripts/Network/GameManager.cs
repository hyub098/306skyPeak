using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//prefab name, should be in Resource folder
	public string playerPrefabName = "OnlineOwl";
	public Camera camera;
	public Canvas start;
	void OnJoinedRoom()
	{
		StartGame();

	}
	
	IEnumerator OnLeftRoom()
	{
		//reset everything

		//Wait untill Photon is properly disconnected (empty room, and connected back to main server)
		while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
			yield return 0;
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	void StartGame()
	{
		// Spawn our local player
		camera.enabled = false;
		Vector3 location = new Vector3 (-80f,98f,112f);
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
		
		if (GUILayout.Button("Leave Room"))
		{
			PhotonNetwork.LeaveRoom();
			start.enabled=false;
		}
	}
	
	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}    
}
