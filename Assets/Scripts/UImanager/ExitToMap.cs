using UnityEngine;
using System.Collections;

public class ExitToMap : MonoBehaviour {

	public void OnClick(){
		Application.LoadLevel ("map");
	}
}
