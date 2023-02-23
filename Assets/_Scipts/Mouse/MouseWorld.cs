using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    [SerializeField] private LayerMask floorLayerMask;
    [SerializeField] private LayerMask unitLayerMask;

    public static MouseWorld Instance { get; private set; }

    
    private void Awake()
    {
        Instance = this;
    }
    
    public static MouseFloorClickedInfo GetMouseMovementInfo()
    {
        var mouseInfo = new MouseFloorClickedInfo();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mouseInfo.IsHit = Physics.Raycast(ray, out RaycastHit hit,float.MaxValue ,Instance.floorLayerMask);
        mouseInfo.HitPoint = hit.point;

        return mouseInfo;
    }

    public static MouseUnitClickedInfo GetMouseUnitInfo()
    {
        var unitInfo = new MouseUnitClickedInfo();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        unitInfo.IsClickAnyUnit = false;
        unitInfo.ClickedUnit = null;
        
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, Instance.unitLayerMask))
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

    public Vector3 GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, floorLayerMask);
        return hit.point;
    }
    
    
}

