using System.Collections;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    [Header("Jump SFX")]
    [SerializeField] AudioSource _jumpAudioSource;
    [SerializeField] AudioClip _jumpAudioClip;

    [Header("Brush SFX")]
    [SerializeField] AudioSource _swooshAudioSource;
    [SerializeField] AudioSource _splashAudioSource;

    public void PlayJumpSFX()
    {
        _jumpAudioSource.Stop();
        _jumpAudioSource.Play();
    }

    public void PlaySwooshSFX()
    {
        _swooshAudioSource.Stop();
        _swooshAudioSource.Play();
    }

    public void PlaySplashSFX()
    {
        _splashAudioSource.Stop();
        _splashAudioSource.Play();
    }
}
