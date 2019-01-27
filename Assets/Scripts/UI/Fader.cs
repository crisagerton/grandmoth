using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {
    public Texture2D fadeOutTexture;

    public float sceneFadeSpeed;
    public float sceneSlowFadeSpeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1;

    private float currentFadeSpeed;

    public float audioFadeSpeed;
    private int audioFadeDirection = -1;
    private float volume = 1.0f;

    private void Awake()
    {
        currentFadeSpeed = sceneFadeSpeed;
    }

    private void OnGUI()
    {
        alpha += fadeDirection * currentFadeSpeed * Time.unscaledDeltaTime;
        alpha = Mathf.Clamp01(alpha);
        
        volume -= audioFadeDirection * audioFadeSpeed * Time.unscaledDeltaTime;
        volume = Mathf.Clamp01(volume);

        GetComponent<AudioSource>().volume = volume;

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginSceneFade(int direction)
    {
        currentFadeSpeed = sceneFadeSpeed;
        fadeDirection = direction;
        return (currentFadeSpeed);
    }

    public float SlowDownFade(int direction)
    {
        currentFadeSpeed = sceneSlowFadeSpeed;
        fadeDirection = direction;
        return (currentFadeSpeed);
    }

    public float InstantFade(int direction)
    {
        currentFadeSpeed = 0;
        audioFadeDirection = direction;
        return (currentFadeSpeed);
    }

    public void BeginAudioFade(int direction)
    {
        audioFadeDirection = direction;
    }

    void OnLevelLoaded()
    {
        BeginSceneFade(-1);
    }
}
