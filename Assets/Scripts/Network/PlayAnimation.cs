using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	public Animation animation;
	
	void Start() {
		animation = GetComponent<Animation>();
		StartCoroutine(MyCoroutine());
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
