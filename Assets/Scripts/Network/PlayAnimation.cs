using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	public Animation animation;
	public bool canOpen=true;
	void Start() {
		animation = GetComponent<Animation>();
		if (canOpen) {
			animation.Play ("open");
		}

	}
	void Update(){

	}
	
	void RepeatMyCoroutine() {
		StartCoroutine(MyCoroutine());
	}
	
	private IEnumerator MyCoroutine() {
		animation.Play("open");
		yield return new WaitForSeconds(5f);
		animation.Play("close");
		yield return new WaitForSeconds(5f);
		RepeatMyCoroutine();

	}
}
