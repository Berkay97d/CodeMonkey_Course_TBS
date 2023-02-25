using System;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float stopingTreshold;
    [SerializeField] private float unitSpeed;
    [SerializeField] private float rotateSpeed;

    public bool IsWalking { get; private set; }

    private Vector3 targetPosition;
    private Vector3 direction;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
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

    private void HandleRotation()
    {
        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        
    }
    
    public void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }
}
