using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static event EventHandler OnAnyActionPointChanged;
    
    private GridPosition currentGridPosition;
    private MoveAction moveAction;
    private SpinAction spinAction;
    private BaseAction[] actions;
    private int actionPoints = 3;


    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
        actions = GetComponents<BaseAction>();
    }

    private void Start()
    {
        currentGridPosition = LevelGrid.Instance.GridFromWorld(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);
        
        TurnSystem.Instance.OnTurnChanged += OnTurnChanged;
    }

    private void OnTurnChanged(object sender, EventArgs e)
    {
        actionPoints = 3;
        
        OnAnyActionPointChanged?.Invoke(this, EventArgs.Empty);
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

    public SpinAction GetSpinAction()
    {
        return spinAction;
    }
    
    public override string ToString()
    {
        return "Unit: " + name;
    }

    public GridPosition GetGridPosition()
    {
        return currentGridPosition;
    }

    public BaseAction[] GetActions()
    {
        return actions;
    }

    public bool TrySpendActionPoints(BaseAction baseAction)
    {
        if (actionPoints >= baseAction.GetActionCost())
        {
            actionPoints -= baseAction.GetActionCost();
            
            OnAnyActionPointChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }

        return false;
    }

    public int GetActionPoints()
    {
        return actionPoints;
    }
    
    
}
