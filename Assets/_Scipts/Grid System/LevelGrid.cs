using UnityEngine;


public class LevelGrid : MonoBehaviour
{
    private GridSystem gridSystem;
    [SerializeField] private Transform prefab;
        
    
    private void Awake()
    {
        gridSystem = new GridSystem(10, 10, 1f);
        gridSystem.CreateDebugObjects(prefab);
    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        
    }
}
