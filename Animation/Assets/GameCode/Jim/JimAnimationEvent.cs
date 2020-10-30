using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JimAnimationEvent : MonoBehaviour
{
    private JimController jimController;
    private AudioSource audioSource;
    private Animator animator;
    private int isJumping = Animator.StringToHash("isJumping");

    private void Awake()
    {
        jimController = GetComponentInParent<JimController>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void JumpStop()
    {
        animator.SetBool(isJumping, false);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
