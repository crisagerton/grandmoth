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

    private bool player1Pause = false;
    private bool player2Pause = false;

    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        player1Pause = false;
        player2Pause = false;
    }

    private void Update() {
		if (player1Pause && !buttonSelected)
        {
            if (player1DirectionCheck())
            {
                eventSystem.SetSelectedGameObject(selectedObject);
                buttonSelected = true;
            }
        }

        if (player2Pause && !buttonSelected)
        {
            if (player2DirectionCheck())
            {
                eventSystem.SetSelectedGameObject(selectedObject);
                buttonSelected = true;
            }
        }
	}

    private bool player1DirectionCheck()
    {
        if (horizontalControlled && verticalControlled)
            return Input.GetAxisRaw("DPadHorizontal1") != 0 || Input.GetAxisRaw("DPadVertical1") != 0;
        else if (horizontalControlled)
            return Input.GetAxisRaw("DPadHorizontal1") != 0;
        else if (verticalControlled)
            return Input.GetAxisRaw("DPadVertical1") != 0;

        return false;
    }

    private bool player2DirectionCheck()
    {
        if (horizontalControlled && verticalControlled)
            return Input.GetAxisRaw("DPadHorizontal2") != 0 || Input.GetAxisRaw("DPadVertical2") != 0;
        else if (horizontalControlled)
            return Input.GetAxisRaw("DPadHorizontal2") != 0;
        else if (verticalControlled)
            return Input.GetAxisRaw("DPadVertical2") != 0;

        return false;
    }

    public void setPlayer1Pause(bool paused)
    {
        player1Pause = paused;
    }

    public void setPlayer2Pause(bool paused)
    {
        player2Pause = paused;
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
