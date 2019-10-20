using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip OKButton;
    public AudioClip GrassMove;
    public AudioClip OK;
    public AudioClip NG;
    public AudioClip Correct;
    public AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOKButton()
    {
        audioSource.PlayOneShot(OKButton);
    }

    public void PlayGrassMove()
    {
        audioSource.PlayOneShot(GrassMove);
    }

    public void PlayOK()
    {
        audioSource.PlayOneShot(OK);
    }

    public void PlayNG()
    {
        audioSource.PlayOneShot(NG);
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(Correct);
    }
}
