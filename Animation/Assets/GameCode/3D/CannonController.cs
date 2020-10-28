using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CannonController : MonoBehaviour
{

    private Animator anim;
    private int shootTrigger = Animator.StringToHash("Shoot");
    private int goTrigger = Animator.StringToHash("Go");
    private int stopTrigger = Animator.StringToHash("Stop");

    [SerializeField] private AnimationClip shootSphereClip = default;
    [SerializeField] private AnimationClip shootCubeClip = default;
    [SerializeField] private string cubeAmmoName = "Cube";
    [SerializeField] private string sphereAmmoName = "Sphere";
    [SerializeField] private string shootAnimationName = "ShootAnimation";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        anim.SetTrigger(shootTrigger);
    }

    public void Go()
    {
        anim.SetTrigger(goTrigger);
    }
    public void Stop()
    {
        anim.SetTrigger(stopTrigger);
    }

    public void ChangeAmmo(string ammo)
    {
        var overrideAnimator = new AnimatorOverrideController(anim.runtimeAnimatorController);
        if (ammo == cubeAmmoName)
        {
            overrideAnimator[shootAnimationName] = shootCubeClip;
        }
        else if (ammo == sphereAmmoName)
        {
            overrideAnimator[shootAnimationName] = shootSphereClip;
        }
        anim.runtimeAnimatorController = overrideAnimator;
    }
}
