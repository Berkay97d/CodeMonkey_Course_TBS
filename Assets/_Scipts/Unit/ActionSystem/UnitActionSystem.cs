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
    
    private Unit selectedUnit;
    private bool isBusy;

    
    private void Awake()
    {
        Instance = this;
        selectedUnit = GameObject.Find("Unit_1").GetComponent<Unit>();
    }

    private void Update()
    {
        if(TryChangeSelectedUnit()) return;
        if(isBusy) return;

        HandleSelectedUnitMovement();
        HandleSelectedUnitRotation();
    }

    private void HandleSelectedUnitMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouse = MouseWorld.GetMouseMovementInfo();

            if (!mouse.IsHit) return;

            var mouseGridPos = LevelGrid.Instance.GridFromWorld(MouseWorld.Instance.GetMousePosition());

            if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPos))
            {
                SetBusy();
                selectedUnit.GetMoveAction().Move(mouseGridPos, Release);
            }
        }
    }

    private void HandleSelectedUnitRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetBusy();
            selectedUnit.GetSpinAction().Spin(Release);
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

    private void SetSelectedUnit(Unit unit)
    {
        OnSelectedUnitChanged?.Invoke(this, new OnSelectedUnitChangedEventArgs
        {
            OldUnit = selectedUnit,
            NewUnit = unit,
        });
        
        selectedUnit = unit;
    }

    private void SetBusy()
    {
        isBusy = true;
    }

    private void Release()
    {
        isBusy = false;
        Debug.Log("RELEASED");
    }
    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
    
    
}
