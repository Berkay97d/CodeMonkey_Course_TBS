using System;
using UnityEngine;

public class BaseAction :  MonoBehaviour
{
    protected Unit unit;
    protected bool isActive;

    
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }
}
