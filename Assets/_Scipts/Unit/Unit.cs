using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float unitSpeed;
    [SerializeField] private float stopingTreshold;
    [SerializeField] private float rotateSpeed;
    
    public bool IsWalking { get; private set; }
    
    private Vector3 targetPosition;
    private Vector3 direction;

    private void Update()
    {
        HandleMovement();
        HandleRotation();

        if (Input.GetMouseButtonDown(0))
        {
            var mouse = MouseWorld.GetMouseInfo();
            
            if (!mouse.IsHit) return;
            
            Move(mouse.HitPoint);
        }
    }

    private void HandleRotation()
    {
        transform.forward = Vector3.Lerp(transform.forward,direction, Time.deltaTime * rotateSpeed);
    }
    
    private void HandleMovement()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stopingTreshold)
        {
            direction = (targetPosition - transform.position).normalized;
            transform.position += direction * unitSpeed * Time.deltaTime;
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }
    }


    private void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }



}
