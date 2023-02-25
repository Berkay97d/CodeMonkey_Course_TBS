using UnityEngine;



public class GridSystem
{
    private readonly int width;
    private readonly int height;
    private readonly float cellSize;
    private readonly GridObject[,] gridArray;
    
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new GridObject[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var gridPosition = new GridPosition(x, z);
                var grid = new GridObject(this, gridPosition);
                
                gridArray[x, z] = grid;
            }
        }
    }

    public Vector3 WorldFromGrid(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GridFromWorld(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var gridPos = new GridPosition(x, z);
                
                var debugTransform = GameObject.Instantiate(debugPrefab, WorldFromGrid(gridPos), Quaternion.identity);
                
                var gridDebugObj = debugTransform.GetComponent<GridDebugObject>();
                
                gridDebugObj.MyGridObject = GetGrid(gridPos);
            }
        }
    }

    public GridObject GetGrid(GridPosition gridPosition)
    {
        return gridArray[gridPosition.x, gridPosition.z];
    }

    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height;
        
    }
    
}
