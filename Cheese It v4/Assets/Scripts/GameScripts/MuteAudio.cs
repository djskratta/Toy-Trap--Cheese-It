using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour {
	public AudioSource MoveNoise;
	
	void Awake(){
		MoveNoise.volume = 0f;		
	}
	
	void Start(){
		
	}
}



