using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameOver : MonoBehaviour {
		public Canvas gameOverScreen;
		public AudioSource BGMusic;
		
		void OnCollisionEnter (Collision col)
		{
			if(col.gameObject.name == "Guard")
			{
				BGMusic.mute = true;
				gameOverScreen.gameObject.SetActive(true);
				GetComponent<RigidbodyFirstPersonController>().enabled = false;
			}
		}
	}
}