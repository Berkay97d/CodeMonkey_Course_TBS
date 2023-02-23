using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionSystem : MonoBehaviour
{
    public class OnSelectedUnitChangedEventArgs : EventArgs
    {
        public Unit OldUnit { get; set; }
        public Unit NewUnit { get; set; }
    }
    public static event EventHandler<OnSelectedUnitChangedEventArgs> OnSelectedUnitChanged;
    
    private Unit selectedUnit;

    private void Awake()
    {
        selectedUnit = GameObject.Find("Unit_1").GetComponent<Unit>();
    }

    private void Update()
    {
        if(TryChangeSelectedUnit()) return;

        HandleSelectedUnitMovement();
    }

    private void HandleSelectedUnitMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouse = MouseWorld.GetMouseMovementInfo();

            if (!mouse.IsHit) return;

            selectedUnit.Move(mouse.HitPoint);
        }
    }

    private bool TryChangeSelectedUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var unitInfo = MouseWorld.GetMouseUnitInfo();

            if (unitInfo.ClickedUnit != null && unitInfo.ClickedUnit != selectedUnit)
            {
                OnSelectedUnitChanged?.Invoke(this, new OnSelectedUnitChangedEventArgs
                {
                    OldUnit = selectedUnit,
                    NewUnit = unitInfo.ClickedUnit
                });
                
                selectedUnit = unitInfo.ClickedUnit;
                return unitInfo.IsClickAnyUnit;
            }

            return unitInfo.IsClickAnyUnit;
        }

        return false;
    }
}
