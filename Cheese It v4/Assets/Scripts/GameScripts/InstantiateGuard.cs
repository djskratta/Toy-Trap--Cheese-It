using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.Characters.ThirdPerson{
public class InstantiateGuard : MonoBehaviour {

	public Transform guard;
	public Transform startingPoint;
	public Transform[] points;

    // instantiate guard
    void Awake () {
		guard.GetComponent<AICharacterControl>().SetTarget(gameObject.transform);
		guard.GetComponent<AICharacterControl>().SetPoints(points);
		Instantiate(guard, startingPoint);
    }
    
    // Update is called once per frame
    void Update ()
    {
    }

    private void OnDisable()
    {
    }
}
}