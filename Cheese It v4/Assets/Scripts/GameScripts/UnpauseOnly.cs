using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class UnpauseOnly : MonoBehaviour {
		public void Unpause(){
			Time.timeScale = 1.0f;
		}
	}
}