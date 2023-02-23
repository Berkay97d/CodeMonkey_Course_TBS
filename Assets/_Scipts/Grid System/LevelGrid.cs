using UnityEngine;


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

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        gridObj.UnitOn = unit;
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        return gridObj.UnitOn;
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        var gridObj = gridSystem.GetGrid(gridPosition);
        gridObj.UnitOn = null;
    }

    public GridPosition GridFromWorld(Vector3 worldPos)
    {
        return gridSystem.GripFromWorld(worldPos);
    }
}
