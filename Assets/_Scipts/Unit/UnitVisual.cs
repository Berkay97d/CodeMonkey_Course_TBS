
using System;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GameObject visual;
    
    private void Start()
    {
        UnitSelectionSystem.Instance.OnSelectedUnitChanged += OnSelectedUnitChanged;
    }

    private void OnSelectedUnitChanged(object sender, UnitSelectionSystem.OnSelectedUnitChangedEventArgs e)
    {
        if (e.NewUnit == unit)
        {
            Show();
        }
        else if (e.OldUnit == unit)
        {
            Hide();
        }
    }

    private void Show()
    {
        visual.SetActive(true);
    }

    private void Hide()
    {
        visual.SetActive(false);
    }
}
