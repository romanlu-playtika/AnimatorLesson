using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JimAnimationEvent : MonoBehaviour
{
    private JimController jimController;
    private AudioSource audioSource;

    private void Awake()
    {
        jimController = GetComponentInParent<JimController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void JumpStop()
    {
        if (jimController != null)
        {
            jimController.Jump();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private void ResetIdle()
    {
        if (jimController != null)
        {
            jimController.ResetIdleTimer();
        }
    }
}
