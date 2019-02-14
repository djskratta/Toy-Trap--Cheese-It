using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameOver : MonoBehaviour {
		public Canvas gameOverScreen;
		
		void OnCollisionEnter (Collision col)
		{
			if(col.gameObject.name == "Guard")
			{
				gameOverScreen.gameObject.SetActive(true);
				GetComponent<RigidbodyFirstPersonController>().enabled = false;
			}
		}
	}
}