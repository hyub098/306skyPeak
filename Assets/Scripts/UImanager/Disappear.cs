using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour {

	public Canvas Canvasorg;

	public Canvas Help;

	public void onClick(){
		Canvasorg.enabled = false;
		Help.enabled=true;
	}
}
