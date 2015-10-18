using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	public Animation animation;
	public bool openDoor;
	public bool isOpen;
	
	void Start() {
		animation = GetComponent<Animation>();
		isOpen = false;
		openDoor = false;
//		count = 0;
//		StartCoroutine (MyCoroutine);
		}

	void Update(){
		if (!isOpen && openDoor) {
			animation.Play ("open");
			isOpen=true;
		}
		
	}


//	void RepeatMyCoroutine() {
//		StartCoroutine(MyCoroutine());
//	}
//	
//	private IEnumerator MyCoroutine() {
//		animation.Play("open");
//		yield return new WaitForSeconds(50f);
//		animation.Play("close");
//		yield return new WaitForSeconds(50f);
//		RepeatMyCoroutine();
//
//	}
}
