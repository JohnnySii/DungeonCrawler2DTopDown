using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField]
    protected float pitchRnd = 0.05f;
    protected float basePitch;

    [SerializeField]
    protected AudioClip stepClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    protected void PlayClipVariablePitch(AudioClip clip)
    {
        var rndPitch = UnityEngine.Random.Range(-pitchRnd, pitchRnd);
        audioSource.pitch = basePitch + rndPitch;
        PlayClip(clip);


    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

    }

    public void PlayStepSound()
    {
        PlayClipVariablePitch(stepClip);


    }
}
