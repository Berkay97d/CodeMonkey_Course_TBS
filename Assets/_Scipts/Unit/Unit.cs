using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float unitSpeed;
    [SerializeField] private float stopingTreshold;

    public bool IsWalking { get; private set; }
    
    private Vector3 targetPosition;


    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stopingTreshold)
        {
            var moveDir = (targetPosition - transform.position).normalized;
            transform.position += moveDir * unitSpeed * Time.deltaTime;
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }


        if (Input.GetMouseButtonDown(0))
        {
            var mouse = MouseWorld.GetMouseInfo();
            
            if (!mouse.IsHit) return;
            
            Move(mouse.HitPoint);
        }
    }


    private void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }



}
