using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBusyUI : MonoBehaviour
{
    [SerializeField] private GameObject busyVisual;
    
    
    private void Start()
    {
        UnitActionSystem.Instance.OnBusyStateChanged += OnBusyStateChanged;
    }

    private void OnBusyStateChanged(object sender, bool e)
    {
        if (e)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        busyVisual.SetActive(true);
    }

    private void Hide()
    {
        busyVisual.SetActive(false);
    }
}
