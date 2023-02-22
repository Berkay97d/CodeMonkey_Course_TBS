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
        var mouseInfo = MouseWorld.GetMouseInfo();
        
        if (mouseInfo.IsHit)
        {
            renderer.enabled = true;
            transform.position = mouseInfo.HitPoint;
            return;
        }

        renderer.enabled = false;

    }
    
}
