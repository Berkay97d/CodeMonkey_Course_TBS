using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;

    private static MouseWorld instance;


    private void Awake()
    {
        instance = this;
    }
    
    public static MouseInfo GetMouseInfo()
    {
        var mouseInfo = new MouseInfo();
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        mouseInfo.IsHit = Physics.Raycast(ray, out RaycastHit hit,float.MaxValue ,instance.layerMask);
        mouseInfo.HitPoint = hit.point;

        return mouseInfo;
    }
    
    
}

