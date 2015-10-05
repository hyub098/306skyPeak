using UnityEngine;
using System.Collections;

public class ExitToMap : MonoBehaviour {


	//Change scene to map
	public void OnClick(){
		Application.LoadLevel ("map");
	}
}
