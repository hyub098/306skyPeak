using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour
{
	public Camera camera;
	public Canvas start;
	//default room name
	private string roomName = "SkyPeakRoom1";
	private Vector2 scrollPos = Vector2.zero;

	void Awake()
	{
		start.enabled = false;

		//Connect to the main photon server. 
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings("v1.0"); // version of the game.	
		//Load name from PlayerPrefs
		PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999));		
	}
	
	//display the main screen for multiplayer,including creating room, joining room, going back to main screen
	void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			ShowConnectingGUI();
			return;   //Wait for a connection
		}
		
		
		if (PhotonNetwork.room != null)
			return; //Only when we're not in a Room

        GUI.skin.label.fontSize = 13;
        GUI.skin.button.fontSize = 13;
        GUILayout.BeginArea(new Rect((Screen.width - 380) / 2, (Screen.height - 300) / 2, 380, 300));
		
		GUILayout.Label("Main Menu");
		
		//Player name
		GUILayout.BeginHorizontal();
		GUILayout.Label("Player name:", GUILayout.Width(150));
		PhotonNetwork.playerName = GUILayout.TextField(PhotonNetwork.playerName);
		if (GUI.changed)//Save name
			PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		GUILayout.EndHorizontal();
		
		GUILayout.Space(15);
		
		
		//Join room by title
		GUILayout.BeginHorizontal();
		GUILayout.Label("JOIN ROOM:", GUILayout.Width(150));
		roomName = GUILayout.TextField(roomName);
		if (GUILayout.Button("GO"))
		{
			PhotonNetwork.JoinRoom(roomName);
		}
		GUILayout.EndHorizontal();
		
		//Create a room (fails if exist!)
		GUILayout.BeginHorizontal();
		GUILayout.Label("CREATE ROOM:", GUILayout.Width(150));
		roomName = GUILayout.TextField(roomName);
		if (GUILayout.Button("GO"))
		{
			// using null as TypedLobby parameter will also use the default lobby
			PhotonNetwork.CreateRoom(roomName, new RoomOptions() { maxPlayers = 10 }, TypedLobby.Default);
		}
		GUILayout.EndHorizontal();
		
		//Join random room
		GUILayout.BeginHorizontal();
		GUILayout.Label("JOIN RANDOM ROOM:", GUILayout.Width(150));
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("..no games available right now..");
		}
		else
		{
			if (GUILayout.Button("GO"))
			{
				PhotonNetwork.JoinRandomRoom();
			}
		}
		GUILayout.EndHorizontal();
		
		GUILayout.Space(30);
		GUILayout.Label("ROOM LISTING:");
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("..no games available right now..");
		}
		else
		{
			//Room listing: simply call GetRoomList.
			scrollPos = GUILayout.BeginScrollView(scrollPos);
			foreach (RoomInfo game in PhotonNetwork.GetRoomList())
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(game.name + " " + game.playerCount + "/" + game.maxPlayers);
				if (GUILayout.Button("JOIN"))
				{
					PhotonNetwork.JoinRoom(game.name);
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
		}
		GUILayout.BeginHorizontal();
		GUILayout.Space(40);
		GUILayout.Label("", GUILayout.Width(70));
		//button to go back to map
		if (GUILayout.Button("Exit", GUILayout.Width(150)))
		{
			PhotonNetwork.LeaveRoom();
			Application.LoadLevel(Application.loadedLevel);
			Application.LoadLevel(1);
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	//GUI when it's connecting to the server
	void ShowConnectingGUI()
	{
        GUI.skin.label.fontSize = 13;
        GUILayout.BeginArea(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 300));		
		GUILayout.Label("Connecting to Photon server.");	
		GUILayout.EndArea();
	}
}
