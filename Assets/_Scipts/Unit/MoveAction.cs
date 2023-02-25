using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float stopingTreshold;
    [SerializeField] private float unitSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int maxMoveRange;
    

    public bool IsWalking { get; private set; }

    private Unit unit;
    private Vector3 targetPosition;
    private Vector3 direction;
    private readonly List<GridPosition> validGridPositions = new List<GridPosition>();

    private void Awake()
    {
        unit = GetComponent<Unit>();
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

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        return validGridPositions.Contains(gridPosition);
    }
    public List<GridPosition> GetValidGridPositionList()
    {
        validGridPositions.Clear();
        
        var unitGridPosition = unit.GetGridPosition();
        
        for (int x = -maxMoveRange; x <= maxMoveRange; x++)
        {
            for (int z = -maxMoveRange ; z <= maxMoveRange; z++)
            {
                var offsetGridPos = new GridPosition(x, z);
                var testGridPos = unitGridPosition + offsetGridPos;

                if (unitGridPosition == testGridPos)
                {
                    continue;
                }
                
                if (!LevelGrid.Instance.IsValidGridPosition(testGridPos))
                {
                    continue;
                }
                
                if (LevelGrid.Instance.HasAnyUnitOnGrid(testGridPos))
                {
                    continue;
                }
                
                validGridPositions.Add(testGridPos);
                Debug.Log(testGridPos);
            }
        }
        
        return validGridPositions;
    }
}
