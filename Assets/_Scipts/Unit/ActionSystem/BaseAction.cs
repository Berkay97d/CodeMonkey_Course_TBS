using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction :  MonoBehaviour
{
    protected Unit unit;
    protected bool isActive;
    protected Action onActionComplete;


    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public abstract string GetActionName();

    public abstract void DoAction(GridPosition gridPosition, Action action);
    
    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        return GetValidGridPositionList().Contains(gridPosition);
    }

    public abstract List<GridPosition> GetValidGridPositionList();

    public virtual int GetActionCost()
    {
        return 1;
    }
    
}
