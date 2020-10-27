using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void PlayJumpSound()
    {
        audioSource.Play();
    }
}
