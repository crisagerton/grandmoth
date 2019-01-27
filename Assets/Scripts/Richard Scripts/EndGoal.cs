using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class EndGoal : MonoBehaviour
{
    private Fader fade;
    private List<GameObject> players = new List<GameObject>();
    public CinemachineVirtualCamera cm;

    public float duration = 3f;

    private float startTime;
    private float maxOthSize = 5.35f;
    private float startOthSize = 3f;

    private bool activeTimer = false;
    private bool active = false;
    
    void Awake()
    {
        fade = GameObject.Find("GameManager").GetComponent<Fader>();

        active = false;
        activeTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2 && !active)
        {
            active = true;
            //LoadNextLevel();
            PlayCutscene();
        }

        if (activeTimer)
        {
            float t = (Time.unscaledTime - startTime) / duration;

            if (t > 1)
                activeTimer = false;
            else
                cm.m_Lens.OrthographicSize = Mathf.SmoothStep(startOthSize, maxOthSize, t);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Light" || collision.tag == "Moth")
            players.Add(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Light" || collision.tag == "Moth")
            players.Remove(collision.gameObject);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 0;
        StartCoroutine(FadeWait(SceneManager.GetActiveScene().buildIndex)); // ADD ONE FOR NEXT LEVEL CURRENTLY LOOPING
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);

        yield return new WaitForSecondsRealtime(fadeTime);

        Time.timeScale = 1;

        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void PlayCutscene()
    {
        StartCoroutine(CutSceneAnimation());
    }

    IEnumerator CutSceneAnimation()
    {
        float fadeTime = fade.SlowDownFade(1);

        yield return new WaitForSecondsRealtime(fadeTime);

        fadeTime = fade.SlowDownFade(-1);

        yield return new WaitForSecondsRealtime(fadeTime - 0.5f);

        cm.Follow = null;
        cm.LookAt = null;

        startTime = Time.unscaledTime;
        activeTimer = true;

        while (activeTimer)
        {
            break;
        }

    }
}
