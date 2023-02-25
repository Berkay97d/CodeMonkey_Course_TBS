using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private MoveAction moveAction;
    
    private GridPosition currentGridPosition;

    
    private void Start()
    {
        currentGridPosition = LevelGrid.Instance.GridFromWorld(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);
    }

    private void Update()
    {
        CheckGridPosition();
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
    
    public MoveAction GetMoveAction()
    {
        return moveAction;
    }
    
    public override string ToString()
    {
        return "Unit: " + name;
    }

    public GridPosition GetGridPosition()
    {
        return currentGridPosition;
    }
    
    
}
