using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cutscene : MonoBehaviour
{
    public CinemachineVirtualCamera cm;

    public float duration = 3f;
    private Fader fade;
    private float startTime;
    private float maxOthSize = 5.35f;
    private float startOthSize = 3f;

    private bool activeTimer = false;

    void Start()
    {
        PlayCutscene();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer)
        {
            float t = (Time.unscaledTime - startTime) / duration;

            if (t > 1)
                activeTimer = false;
            else
                cm.m_Lens.OrthographicSize = Mathf.SmoothStep(startOthSize, maxOthSize, t);
        }
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);

        yield return new WaitForSecondsRealtime(fadeTime);

        Time.timeScale = 1;
    }

    public void PlayCutscene()
    {
        StartCoroutine(CutSceneAnimation());
    }

    IEnumerator CutSceneAnimation()
    {
        cm.Follow = null;
        cm.LookAt = null;

        startTime = Time.unscaledTime;
        activeTimer = true;

        yield return new WaitForSecondsRealtime(duration + 2f);

    }
}
