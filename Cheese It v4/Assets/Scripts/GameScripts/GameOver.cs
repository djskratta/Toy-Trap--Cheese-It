using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameOver : MonoBehaviour {
		public Canvas gameOverScreen;
		public AudioSource BGMusic;
		
		
		void Awake(){
			//Time.timeScale = 0.0f;
		}
		
		void OnCollisionEnter (Collision col)
		{
			if(col.gameObject.tag == "Guard")
			{
				BGMusic.mute = true;
				gameOverScreen.gameObject.SetActive(true);
				GetComponent<RigidbodyFirstPersonController>().enabled = false;
			}
		}
	}
}