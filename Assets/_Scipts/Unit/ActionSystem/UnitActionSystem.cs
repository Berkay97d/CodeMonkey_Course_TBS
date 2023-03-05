using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : MonoBehaviour
{
    public class OnSelectedUnitChangedEventArgs : EventArgs
    {
        public Unit OldUnit { get; set; }
        public Unit NewUnit { get; set; }
    }
    public static UnitActionSystem Instance { get; private set; }
    public event EventHandler<OnSelectedUnitChangedEventArgs> OnSelectedUnitChanged;
    public event EventHandler OnSelectedActionChanged;
    
    private BaseAction selectedAction;
    private Unit selectedUnit;
    private bool isBusy;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetSelectedUnit(GameObject.Find("Unit_1").GetComponent<Unit>());
    }

    private void Update()
    {
        if(isBusy) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(TryChangeSelectedUnit()) return;

        HandleAction();
    }
    
    private void HandleAction()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var mouse = MouseWorld.GetMouseMovementInfo();
        
        if (!mouse.IsHit) return;
        
        var mouseGridPos = LevelGrid.Instance.GridFromWorld(MouseWorld.Instance.GetMousePosition());

        if (selectedAction.IsValidActionGridPosition(mouseGridPos))
        {
            SetBusy();
            selectedAction.DoAction(mouseGridPos, Release);
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
        selectedUnit = unit;
        selectedAction = selectedUnit.GetMoveAction();
        
        OnSelectedUnitChanged?.Invoke(this, new OnSelectedUnitChangedEventArgs
        {
            OldUnit = selectedUnit,
            NewUnit = unit,
        });
        
    }

    public void SetSelectedAction(BaseAction baseAction)
    {
        selectedAction = baseAction;
        
        OnSelectedActionChanged?.Invoke(this, EventArgs.Empty);
    }

    public BaseAction GetSelectedAction()
    {
        return selectedAction;
    }
    
    
    
}
