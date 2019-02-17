using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class Pause : MonoBehaviour {
		public Canvas pauseScreen;
		public GameObject gameOverGameObject;
		public GameObject levelFinishGameObject;
		public GameObject cheeseGetGameObject;
		
		public AudioSource BGMusic;
		
		void Awake(){
			
		}
		
		void Start(){
			
		}
		
		void Update(){
			if(Input.GetButtonDown("Pause") && !(gameOverGameObject.activeSelf) && !(levelFinishGameObject.activeSelf) && !(cheeseGetGameObject.activeSelf)){
				PauseUnpause();
			}
		}
		
		public void PauseUnpause(){
			if(Time.timeScale == 1.0f){
				Time.timeScale = 0.0f;
				pauseScreen.gameObject.SetActive(true);
				BGMusic.volume = 0.25f;
			}
			else{
				Time.timeScale = 1.0f;
				pauseScreen.gameObject.SetActive(false);
				BGMusic.volume = 0.75f;
			}
		}
	}
}