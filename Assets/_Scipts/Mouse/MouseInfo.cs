using UnityEngine;

public struct MouseInfo
{
    public bool IsHit { get; set; }
    public Vector3 HitPoint { get; set; }
}

public struct UnitMouseInfo
{
    public bool IsClickAnyUnit { get; set; }
    public Unit ClickedUnit { get; set; }
    
    public Vector3 HitPoint { get; set; }
}