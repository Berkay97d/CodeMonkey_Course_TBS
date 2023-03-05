using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainer;
    

    private List<Transform> actionButtons = new List<Transform>();
    
    private void Start()
    {
        CreateUnitActionButtons(UnitActionSystem.Instance.GetSelectedUnit());
        
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystemOnOnSelectedUnitChanged;
    }

    private void UnitActionSystemOnOnSelectedUnitChanged(object sender, UnitActionSystem.OnSelectedUnitChangedEventArgs e)
    {
        CreateUnitActionButtons(e.NewUnit);
    }

    private void CreateUnitActionButtons(Unit selectedUnit)
    {
        ClearOldButtons();

        foreach (var action in selectedUnit.GetActions())
        {
            var button = Instantiate(actionButtonPrefab, actionButtonContainer);
            actionButtons.Add(button.transform);
            button.GetComponent<ActionButtonUI>().SetBaseAction(action);
        }
    }

    private void ClearOldButtons()
    {
        foreach (var button in actionButtons)
        {
            Destroy(button.gameObject);
        }

        actionButtons.Clear();
    }

    private void UpdateSelectedVisual()
    {
        
    }
}
