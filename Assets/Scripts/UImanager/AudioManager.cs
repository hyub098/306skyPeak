using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public Slider volumeSlider;
	public Toggle volumeToggle;

	// Use this for initialization
	void Start () {
		AudioListener.pause = volumeToggle.isOn;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void muteSound(){
		//If toggle to mute, pause the camera's audio listener
		AudioListener.pause = volumeToggle.isOn;
	}

	public void soundVolume(){

		//update audio listener 's volume to the slider's value
		float value = volumeSlider.value;
		Debug.Log (AudioListener.volume);
		AudioListener.volume = value;
	}
}
