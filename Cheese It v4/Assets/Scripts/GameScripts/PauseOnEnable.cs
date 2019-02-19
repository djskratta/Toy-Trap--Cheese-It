using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseOnEnable : MonoBehaviour {
	public AudioSource moveAudio;

	void Awake(){
		moveAudio.Stop();
		Time.timeScale = 0.0f;
	}
}
