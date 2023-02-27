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

    
    private void Awake()
    {
        Instance = this;
        selectedUnit = GameObject.Find("Unit_1").GetComponent<Unit>();
    }

    private void Update()
    {
        if(TryChangeSelectedUnit()) return;

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
                selectedUnit.GetMoveAction().Move(mouseGridPos);
            }
        }
    }

    private void HandleSelectedUnitRotation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedUnit.GetSpinAction().Spin();
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

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
