
using System;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private GameObject visual;
    
    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += OnSelectedUnitChanged;
    }

    private void OnSelectedUnitChanged(object sender, UnitActionSystem.OnSelectedUnitChangedEventArgs e)
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
