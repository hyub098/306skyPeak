using UnityEngine;
using System.Collections;

/**
* This class is used to hide a specific canvas
*/
public class Disappear : MonoBehaviour {

	public Canvas Canvasorg;

	//public Canvas Help;

	public void onClick(){
		Canvasorg.enabled = false;
		//Help.enabled=true;
	}
}
