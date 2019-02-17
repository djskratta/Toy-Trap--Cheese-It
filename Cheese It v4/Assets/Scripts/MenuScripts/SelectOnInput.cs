using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false){
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
		if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Mouse2)){
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
		}
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}