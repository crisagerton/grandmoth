﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActionController : MonoBehaviour {
    private Fader fade;
    private GameObject eventSystem;

    void Awake()
    {
        fade = GameObject.Find("GameManager").GetComponent<Fader>();
        eventSystem = GameObject.Find("EventSystem");
    }

    private void Start()
    {
        eventSystem.SetActive(true);
    }

    public void EnableMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void DisableMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        eventSystem.SetActive(false);
        StartCoroutine(FadeWait(sceneIndex));
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);

        yield return new WaitForSecondsRealtime(fadeTime);

        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        eventSystem.SetActive(false);
        StartCoroutine(FadeQuitWait());
    }

    IEnumerator FadeQuitWait()
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);

        yield return new WaitForSecondsRealtime(fadeTime * 2);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
