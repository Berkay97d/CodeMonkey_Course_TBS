using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }
    public event EventHandler OnTurnChanged;
    public int turnNumber { get; private set; } = 1;


    private void Awake()
    {
        Instance = this;
    }


    public void NextTurn()
    {
        turnNumber++;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }
}
