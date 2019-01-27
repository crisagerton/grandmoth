using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    private Fader fade;
    private List<GameObject> players = new List<GameObject>();

    private bool active = false;
    
    void Awake()
    {
        fade = GameObject.Find("GameManager").GetComponent<Fader>();

        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count == 2 && !active)
        {
            active = true;
            LoadNextLevel();
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

        SceneManager.LoadScene(sceneIndex+1);
    }
}
