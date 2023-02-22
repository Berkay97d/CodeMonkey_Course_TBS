using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationController : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private Animator animator;


    private void Update()
    {
        if (unit.IsWalking)
        {
            StartWalking();
        }
        else
        {
            StartIdle();
        }
    }

    private void StartWalking()
    {
        animator.SetBool("isWalking", true);
    }

    private void StartIdle()
    {
        animator.SetBool("isWalking", false);
    }
    
    
    
    
}
