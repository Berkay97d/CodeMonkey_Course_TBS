using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionSystem : MonoBehaviour
{
    private Unit selectedUnit;

    private void Awake()
    {
        selectedUnit = FindObjectOfType<Unit>();
    }

    private void Update()
    {
        HandleUnitSelection();

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

    private void HandleUnitSelection()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var unit = MouseWorld.GetClickedUnit();

            if (unit != null && unit != selectedUnit)
            {
                Debug.Log("YOK");
                selectedUnit = unit;
            }
        }
    }
}
