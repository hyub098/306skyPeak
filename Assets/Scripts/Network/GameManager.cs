using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// this is a object name (must be in any Resources folder) of the prefab to spawn as player avatar.
	// read the documentation for info how to spawn dynamically loaded game objects at runtime (not using Resources folders)
	public string playerPrefabName = "OnlineOwl";
	public Camera camera;
	void OnJoinedRoom()
	{
		StartGame();
	}
	
	IEnumerator OnLeftRoom()
	{
		//Easy way to reset the level: Otherwise we'd manually reset the camera
		
		//Wait untill Photon is properly disconnected (empty room, and connected back to main server)
		while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
			yield return 0;
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	void StartGame()
	{

		// Spawn our local player
		camera.enabled = false;
		GameObject bird = PhotonNetwork.Instantiate(this.playerPrefabName, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity, 0);
		MoveMent controller = bird.GetComponent<MoveMent>();
		// Enable the camera
		
		controller.isControllable = true;
		Transform playerCam = bird.transform.Find ("Camera");
		playerCam.gameObject.SetActive ( true);

	}
	
	void OnGUI()
	{
		if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room
		
		if (GUILayout.Button("Leave Room"))
		{
			PhotonNetwork.LeaveRoom();
		}
	}
	
	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}    
}
