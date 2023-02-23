using System;
using UnityEngine;

public class MouseVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer renderer;
    
    private void FixedUpdate()
    {
        AdjustPosition();
    }
    
    private void AdjustPosition()
    {
        var mouseInfo = MouseWorld.GetMouseMovementInfo();
        var unitInfo = MouseWorld.GetMouseUnitInfo();

        if (unitInfo.IsClickAnyUnit)
        {
            renderer.enabled = true;
            transform.position = unitInfo.HitPoint;
            return;
        }
        if (mouseInfo.IsHit)
        {
            renderer.enabled = true;
            transform.position = mouseInfo.HitPoint;
            return;
        }

        renderer.enabled = false;

    }
    
}
