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
    
    public static MouseFloorClickedInfo GetMouseMovementInfo()
    {
        var mouseInfo = new MouseFloorClickedInfo();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mouseInfo.IsHit = Physics.Raycast(ray, out RaycastHit hit,float.MaxValue ,instance.floorLayerMask);
        mouseInfo.HitPoint = hit.point;

        return mouseInfo;
    }

    public static MouseUnitClickedInfo GetMouseUnitInfo()
    {
        var unitInfo = new MouseUnitClickedInfo();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        unitInfo.IsClickAnyUnit = false;
        unitInfo.ClickedUnit = null;
        
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, instance.unitLayerMask))
        {
            unitInfo.IsClickAnyUnit = true;
            unitInfo.HitPoint = hit.point;
            
            if (hit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                unitInfo.ClickedUnit = unit;
                return unitInfo;
            }
            
            return unitInfo;
        }
        
        return unitInfo;
    }
    
    
}

