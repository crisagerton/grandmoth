using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrackRandomizer : MonoBehaviour
{

    [Header("Moth Audio Clips")]
    public List<AudioClip> mothAudioClips = new List<AudioClip>();

    [Header("Light Audio Clips")]
    public List<AudioClip> lightAudioClips = new List<AudioClip>();

    [Header("Ambient Audio Clips")]
    public List<AudioClip> ambientAudioClips = new List<AudioClip>();

    [Header("Ambient Interval Timer")]
    public float minIntervalTime = 0f;
    public float maxIntervalTime = 3f;

    private AudioSource audioSource;
    private float timer;
    private bool paused = false;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timer = Random.Range(minIntervalTime, maxIntervalTime);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                audioSource.clip = ambientAudioClips[Random.Range(0, ambientAudioClips.Count - 1)];

                audioSource.Play();

                timer = Random.Range(minIntervalTime, maxIntervalTime);
            }
        }
        
    }

    public AudioClip getMothAudioClip()
    {
        return (mothAudioClips[Random.Range(0, mothAudioClips.Count - 1)]);
    }

    public AudioClip getLightAudioClip()
    {
        return (lightAudioClips[Random.Range(0, lightAudioClips.Count - 1)]);
    }

    public void stopTrack()
    {
        paused = true;
        audioSource.Stop();
    }
}
