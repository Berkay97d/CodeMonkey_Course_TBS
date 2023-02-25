using UnityEngine;
using System.Collections.Generic;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform prefab;

    public static LevelGrid Instance { get; private set; }
    
    private GridSystem gridSystem;


    private void Awake()
    {
        Instance = this;
        
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(prefab);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        gridObj.AddUnit(unit);
    }

    public List<Unit> GetUnitsAtGridPosition(GridPosition gridPosition)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        return gridObj.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        gridObj.RemoveUnit(unit);
    }

    public GridPosition GridFromWorld(Vector3 worldPos)
    {
        return gridSystem.GripFromWorld(worldPos);
    }

    public void ControlUnitChangeGridPosition(Unit unit, GridPosition oldGrid, GridPosition newGrid)
    {
        RemoveUnitAtGridPosition(oldGrid, unit);
        AddUnitAtGridPosition(newGrid, unit);
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridSystem.IsValidGridPosition(gridPosition);
    }

    public bool HasAnyUnitOnGrid(GridPosition gridPosition)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        return gridObj.HasAnyUnit();
    }
}
