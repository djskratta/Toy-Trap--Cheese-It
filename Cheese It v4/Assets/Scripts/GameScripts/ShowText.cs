using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class ShowText : MonoBehaviour {
		void OnEnable()
		{
			StartCoroutine(Show());
		}

		IEnumerator Show()
		{
			gameObject.SetActive(true);
			yield return new WaitForSeconds(3);
			gameObject.SetActive(false);
		}
	}
}