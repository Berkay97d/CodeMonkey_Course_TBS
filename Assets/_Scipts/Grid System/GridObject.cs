﻿
public class GridObject
{

    private GridSystem gridSystem;
    private GridPosition gridPosition;
    public Unit UnitOn { get; set; }

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }
    
    public override string ToString()
    {
        return gridPosition.ToString() + "\n" + UnitOn;
    }
}
