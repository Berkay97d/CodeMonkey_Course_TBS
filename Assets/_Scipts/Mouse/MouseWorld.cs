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

    public static UnitMouseInfo GetMouseUnitInfo()
    {
        var unitInfo = new UnitMouseInfo();
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

