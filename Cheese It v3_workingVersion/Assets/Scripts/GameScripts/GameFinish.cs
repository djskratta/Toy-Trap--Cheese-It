using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class GameFinish : MonoBehaviour {
		public Canvas levelFinishScreen;
		private bool cheeseGet;
		private GameObject cheesePromptText;
		private GameObject cheeseGetText;
		private GameObject cheeseGetImg;
		private GameObject barrier;
		
		void Awake(){
			cheeseGetText = GameObject.Find("Menus/CheeseGet");
			cheeseGetText.gameObject.SetActive(false);
			cheeseGetImg = GameObject.Find("Menus/CheeseGetImg");
			cheeseGetImg.gameObject.SetActive(false);
		}
		
		void Start(){
			cheeseGet = false;
			cheesePromptText = GameObject.Find("Menus/CheesePrompt");
			barrier = GameObject.Find("Exit/Barrier");
		}
		
		void OnTriggerEnter (Collider col)
		{
			//getting the cheese and opening the mousehole
			if(col.gameObject.name == "Cheese")
			{
				Destroy(col.gameObject);
				Destroy(barrier);
				
				cheeseGetText.gameObject.SetActive(true);
				cheeseGetImg.gameObject.SetActive(true);
				cheeseGet = true;
			}
			//reaching the mousehole
			else if(col.gameObject.name == "MouseHole")
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
			else{Debug.Log(col.gameObject.name);}
		}
	}
}