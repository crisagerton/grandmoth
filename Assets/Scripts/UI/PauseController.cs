using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
    public GameObject pauseMenu;
    public List<GameObject> menus;

    public Text pauseTitle;
    
    private bool paused;

    private bool player1Pause;
    private bool player2Pause;

    private SelectOnInput selectOnInput;

    void Start()
    {
        player1Pause = false;
        player2Pause = false;

        selectOnInput = GetComponent<SelectOnInput>();

        pauseMenu.SetActive(false);
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        paused = false;
    }

    void Update() {
	    if (Input.GetButtonDown("Start1"))
        {
            if (!paused)
            {
                Pause();
                player1Pause = true;
                pauseTitle.text = "P1 Pause";
                selectOnInput.setPlayer1Pause(player1Pause);
            }
            else if (paused && player1Pause)
            {
                Resume();
                player1Pause = false;
                selectOnInput.setPlayer1Pause(player1Pause);
            }
        }

        if (Input.GetButtonDown("Start2"))
        {
            if (!paused)
            {
                Pause();
                player2Pause = true;
                pauseTitle.text = "P2 Pause";
                selectOnInput.setPlayer2Pause(player2Pause);
            }
            else if (paused && player2Pause)
            {
                Resume();
                player2Pause = false;
                selectOnInput.setPlayer2Pause(player2Pause);
            }
        }
    }

    public void Pause()
    {
        paused = true;

        pauseMenu.SetActive(true);

        Time.timeScale = 0;
    }

    public void Resume()
    {
        paused = false;

        pauseMenu.SetActive(false);
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        Time.timeScale = 1;
    }
}
