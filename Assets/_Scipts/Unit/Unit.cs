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
    private GridPosition currentGridPosition;

    

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        currentGridPosition = LevelGrid.Instance.GridFromWorld(transform.position);
        LevelGrid.Instance.SetUnitAtGridPosition(currentGridPosition, this);
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        CheckGridPosition();
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

    public void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }

    private void CheckGridPosition()
    {
        var newGridPos = LevelGrid.Instance.GridFromWorld(transform.position);

        if (newGridPos != currentGridPosition)
        {
            LevelGrid.Instance.ControlUnitChangeGridPosition(this, currentGridPosition, newGridPos);
            currentGridPosition = newGridPos;
        }
    }
    
    public override string ToString()
    {
        return "Unit: " + name;
    }
    
    
}
