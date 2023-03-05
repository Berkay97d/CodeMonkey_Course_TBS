using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public class OnSelectedUnitChangedEventArgs : EventArgs
    {
        public Unit OldUnit { get; set; }
        public Unit NewUnit { get; set; }
    }
    public static UnitActionSystem Instance { get; private set; }
    public event EventHandler<OnSelectedUnitChangedEventArgs> OnSelectedUnitChanged;
    public BaseAction selectedAction { get; set; }
    
    private Unit selectedUnit;
    private bool isBusy;


    private void Awake()
    {
        Instance = this;
        SetSelectedUnit(GameObject.Find("Unit_1").GetComponent<Unit>()); 
    }
    
    private void Update()
    {
        if(TryChangeSelectedUnit()) return;
        if(isBusy) return;

        HandleAction();
    }
    
    private void HandleAction()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var mouse = MouseWorld.GetMouseMovementInfo();
        
        if (!mouse.IsHit) return;
        
        var mouseGridPos = LevelGrid.Instance.GridFromWorld(MouseWorld.Instance.GetMousePosition());
        
        switch (selectedAction)
        {
            case MoveAction:
            {
                if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPos))
                {
                    SetBusy();
                    selectedUnit.GetMoveAction().DoAction(mouseGridPos, Release);
                }
            
                return;
            }
            case SpinAction:
                if (selectedUnit.GetSpinAction().IsValidActionGridPosition(mouseGridPos))
                {
                    SetBusy();
                    selectedUnit.GetSpinAction().DoAction(mouseGridPos, Release);
                }
                return;
        }
    }
    
    private bool TryChangeSelectedUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var unitInfo = MouseWorld.GetMouseUnitInfo();

            if (unitInfo.ClickedUnit != null && unitInfo.ClickedUnit != selectedUnit)
            {
                SetSelectedUnit(unitInfo.ClickedUnit);
                return unitInfo.IsClickAnyUnit;
            }

            return unitInfo.IsClickAnyUnit;
        }

        return false;
    }
    
    private void SetBusy()
    {
        isBusy = true;
    }

    private void Release()
    {
        isBusy = false;
    }
    
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    
    private void SetSelectedUnit(Unit unit)
    {
        OnSelectedUnitChanged?.Invoke(this, new OnSelectedUnitChangedEventArgs
        {
            OldUnit = selectedUnit,
            NewUnit = unit,
        });
        
        selectedUnit = unit;
        selectedAction = selectedUnit.GetMoveAction();
    }
    
    
}
