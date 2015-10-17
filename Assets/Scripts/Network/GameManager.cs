using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//prefab name, should be in Resource folder
	public string playerPrefabName = "OnlineOwl";
	public Camera camera;
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
