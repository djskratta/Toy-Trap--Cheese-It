using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameFinish : MonoBehaviour {
		public Canvas levelFinishScreen;
		public GameObject cheese;
		private bool cheeseGet;
		public GameObject cheesePromptText;
		public GameObject cheeseGetText;
		public GameObject cheeseGetImg;
		private GameObject barrier;
		private GameObject mousehole;
		
		void Start(){
			cheeseGet = false;
			mousehole = GameObject.Find("MouseHole/Cylinder");
			barrier = GameObject.Find("Exit/Barrier");
		}
		
		void OnTriggerEnter (Collider col)
		{
			//getting the cheese and opening the mousehole
			if(col.gameObject == cheese)
			{
				Destroy(col.gameObject);
				Destroy(barrier);
				
				cheeseGetText.gameObject.SetActive(true);
				cheeseGetImg.gameObject.SetActive(true);
				cheeseGet = true;
			}
			//reaching the mousehole
			else if(col.gameObject == mousehole)
			{
				//if you got the cheese, complete the game
				if(cheeseGet){
					levelFinishScreen.gameObject.SetActive(true);
					GetComponent<RigidbodyFirstPersonController>().enabled = false;
				}
				//else prompt the user to find the cheese
				else{
					cheesePromptText.gameObject.SetActive(true);
				}
			}
		}
	}
}