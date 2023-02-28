using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    [SerializeField] private float stopingTreshold;
    [SerializeField] private float unitSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private int maxMoveRange;
    
    public bool IsWalking { get; private set; }
    
    private Vector3 targetPosition;
    private Vector3 direction;
    private readonly List<GridPosition> validGridPositions = new List<GridPosition>();

    
    
    protected override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    public override string GetActionName()
    {
        return "Move";
    }
    

    private void Update()
    {
        if (!isActive) return;
        
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
            isActive = false;
            onActionComplete();
        }
    }

    private void HandleRotation()
    {
        Debug.Log("ROTATION");
        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
    }
    
    public override void DoAction(GridPosition gridPosition, Action onMoveComplete)
    {
        onActionComplete = onMoveComplete;
        targetPosition = LevelGrid.Instance.WorldFromGrid(gridPosition);
        isActive = true;
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        return GetValidGridPositionList().Contains(gridPosition);
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
            }
        }
        
        return validGridPositions;
    }
}
