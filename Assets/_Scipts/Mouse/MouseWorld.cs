using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    [SerializeField] private LayerMask floorLayerMask;
    [SerializeField] private LayerMask unitLayerMask;

    private static MouseWorld instance;

    private void Awake()
    {
        instance = this;
    }
    
    public static MouseInfo GetMouseMovementInfo()
    {
        var mouseInfo = new MouseInfo();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mouseInfo.IsHit = Physics.Raycast(ray, out RaycastHit hit,float.MaxValue ,instance.floorLayerMask);
        mouseInfo.HitPoint = hit.point;

        return mouseInfo;
    }

    public static Unit GetClickedUnit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, instance.unitLayerMask))
        {
            if (hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                return unit;
            }
        }
        
        return null;
    }
    
    
}

