using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	public Animation animation;
	public bool openDoor;
	private bool isOpen;
	void Start() {
		animation = GetComponent<Animation>();
		isOpen = false;
		openDoor = false;
		}
	void Update(){
		if (!isOpen && openDoor) {
			animation.Play ("open");
			isOpen=true;
		}
	}
//	
//	void RepeatMyCoroutine() {
//		StartCoroutine(MyCoroutine());
//	}
//	
//	private IEnumerator MyCoroutine() {
//		animation.Play("open");
//		yield return new WaitForSeconds(5f);
//		animation.Play("close");
//		yield return new WaitForSeconds(5f);
//		RepeatMyCoroutine();
//
//	}
}
