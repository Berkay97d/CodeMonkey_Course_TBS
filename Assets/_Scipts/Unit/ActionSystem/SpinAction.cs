using System;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] private float spinAddAmount;
    
    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive) return;
        
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        totalSpinAmount += spinAddAmount;
        
        Debug.Log("ACTİVE");

        if (totalSpinAmount >= 360)
        {
            isActive = false;
            onActionComplete();
        }
    }

    public override void DoAction(GridPosition gridPosition, Action onSpinComplete)
    {
        onActionComplete = onSpinComplete;
        isActive = true;
        totalSpinAmount = 0f;
    }

    public override List<GridPosition> GetValidGridPositionList()
    {
        var validGridPos = new List<GridPosition>();
        validGridPos.Add(unit.GetGridPosition());

        return validGridPos;
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override int GetActionCost()
    {
        return 2;
    }
}
