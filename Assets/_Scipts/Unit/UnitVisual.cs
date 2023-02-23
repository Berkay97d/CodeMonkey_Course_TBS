
using System;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GameObject visual;
    
    private void Start()
    {
        UnitSelectionSystem.OnSelectedUnitChanged += OnSelectedUnitChanged;
    }

    private void OnSelectedUnitChanged(object sender, UnitSelectionSystem.OnSelectedUnitChangedEventArgs e)
    {
        if (e.NewUnit == unit)
        {
            visual.SetActive(true);
        }
        else if (e.OldUnit == unit)
        {
            visual.SetActive(false);
        }
    }
}
