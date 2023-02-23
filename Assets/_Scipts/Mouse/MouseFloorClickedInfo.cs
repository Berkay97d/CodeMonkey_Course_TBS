using UnityEngine;

public struct MouseFloorClickedInfo
{
    public bool IsHit { get; set; }
    public Vector3 HitPoint { get; set; }
}

public struct MouseUnitClickedInfo
{
    public bool IsClickAnyUnit { get; set; }
    public Unit ClickedUnit { get; set; }
    public Vector3 HitPoint { get; set; }
}