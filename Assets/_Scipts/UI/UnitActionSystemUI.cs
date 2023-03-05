using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystemUI : MonoBehaviour
{
    [SerializeField] private ActionButtonUI actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainer;
    

    private List<ActionButtonUI> actionButtons = new List<ActionButtonUI>();
    
    private void Start()
    {
        CreateUnitActionButtons(UnitActionSystem.Instance.GetSelectedUnit());
        UpdateSelectedVisual();
        
        UnitActionSystem.Instance.OnSelectedUnitChanged += OnSelectedUnitChanged;
        UnitActionSystem.Instance.OnSelectedActionChanged += OnSelectedActionChanged;
    }

    private void OnSelectedActionChanged(object sender, EventArgs e)
    {
        UpdateSelectedVisual();
    }

    private void OnSelectedUnitChanged(object sender, UnitActionSystem.OnSelectedUnitChangedEventArgs e)
    {
        CreateUnitActionButtons(e.NewUnit);
        UpdateSelectedVisual();
    }

    private void CreateUnitActionButtons(Unit selectedUnit)
    {
        ClearOldButtons();

        foreach (var action in selectedUnit.GetActions())
        {
            var button = Instantiate(actionButtonPrefab, actionButtonContainer);
            actionButtons.Add(button);
            button.SetBaseAction(action);
        }
    }

    private void ClearOldButtons()
    {
        foreach (var button in actionButtons)
        {
            Destroy(button.transform.gameObject);
        }

        actionButtons.Clear();
    }

    private void UpdateSelectedVisual()
    {
        foreach (var button in actionButtons)
        {
            button.UpdateSelectedVisual();
        }
    }
}
