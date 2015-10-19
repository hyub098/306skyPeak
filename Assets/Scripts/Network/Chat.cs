using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This simple chat example showcases the use of RPC targets and targetting certain players via RPCs.
/// </summary>
/// Reference:Photon Viking template from asset store.
/// Modified By: Skypeak Team
public class Chat : Photon.MonoBehaviour
{
	
	public static Chat SP;
	public List<string> messages = new List<string>();
	
	private int chatHeight = (int)140;
	private Vector2 scrollPos = Vector2.zero;
	private string chatInput = "";
	private float lastUnfocusTime = 0;
	
	void Awake()
	{
		SP = this;
	}
	
	void OnGUI()
	{
        GUI.skin.label.fontSize = 20;
        GUI.SetNextControlName("");
		
		GUILayout.BeginArea(new Rect(0, Screen.height - chatHeight, Screen.width, chatHeight));
		
		//Show scroll list of chat messages
		scrollPos = GUILayout.BeginScrollView(scrollPos);
		GUI.color = Color.red;
		for (int i = messages.Count - 1; i >= 0; i--)
		{
			GUILayout.Label(messages[i]);
		}
		GUILayout.EndScrollView();
		GUI.color = Color.white;
		
		//Chat input
		GUILayout.BeginHorizontal(); 
		GUI.SetNextControlName("ChatField");
		chatInput = GUILayout.TextField(chatInput, GUILayout.MinWidth(200));
		
		if (Event.current.type == EventType.keyDown && Event.current.character == '\n'){
			if (GUI.GetNameOfFocusedControl() == "ChatField")
			{                
				SendChat(PhotonTargets.All);
				lastUnfocusTime = Time.time;
				GUI.FocusControl("");
				GUI.UnfocusWindow();
			}
			else
			{
				if (lastUnfocusTime < Time.time - 0.1f)
				{
					GUI.FocusControl("ChatField");
				}
			}
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	public static void AddMessage(string text)
	{
		SP.messages.Add(text);
		if (SP.messages.Count > 15)
			SP.messages.RemoveAt(0);
	}
	
	
	[PunRPC]
	void SendChatMessage(string text, PhotonMessageInfo info)
	{
		AddMessage("[" + info.sender + "] " + text);
	}
	
	void SendChat(PhotonTargets target)
	{
		if (chatInput != "")
		{
			photonView.RPC("SendChatMessage", target, chatInput);
			chatInput = "";
		}
	}
	
	void SendChat(PhotonPlayer target)
	{
		if (chatInput != "")
		{
			chatInput = "[PM] " + chatInput;
			photonView.RPC("SendChatMessage", target, chatInput);
			chatInput = "";
		}
	}
	//Only available when joining the room
	void OnLeftRoom()
	{
		this.enabled = false;
	}
	
	void OnJoinedRoom()
	{
		this.enabled = true;
	}
	void OnCreatedRoom()
	{
		this.enabled = true;
	}
}
