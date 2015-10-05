using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {
	public Canvas canvas;
	

	//Resume game and disable the pause canva
	public void OnClick(){
		Time.timeScale = 1f; //Resume game
		canvas.enabled = false;
	}
}
