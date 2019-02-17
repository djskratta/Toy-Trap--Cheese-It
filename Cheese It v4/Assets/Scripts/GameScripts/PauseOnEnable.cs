using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class PauseOnEnable : MonoBehaviour {
		
		void Awake(){
			Time.timeScale = 0.0f;
		}
		
		void Start(){
			
		}
		
	}
}