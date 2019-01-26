using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
    public GameObject selectedObject;

    public bool horizontalControlled = false;
    public bool verticalControlled = false;

    private EventSystem eventSystem;
    private bool buttonSelected;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    
    private void Update() {
		if (directionCheck() && !buttonSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
	}

    private bool directionCheck()
    {
        if (horizontalControlled && verticalControlled)
            return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        else if (horizontalControlled)
            return Input.GetAxisRaw("Horizontal") != 0;
        else if (verticalControlled)
            return Input.GetAxisRaw("Vertical") != 0;

        return false;
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
