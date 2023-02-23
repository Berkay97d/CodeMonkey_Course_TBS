using UnityEngine;
using System.Collections.Generic;

public class GridObject
{

    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitsOn = new List<Unit>();

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }
    
    public override string ToString()
    {
        if (unitsOn == null)
        {
            return gridPosition.ToString();
        }

        string unitsString = "";
        foreach (var unit in unitsOn)
        {
            unitsString += unit + "\n";
        }
        return gridPosition.ToString() + "\n" + unitsString;
    }

    public void AddUnit(Unit unit)
    {
        unitsOn.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitsOn.Remove(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitsOn;
    }
}
