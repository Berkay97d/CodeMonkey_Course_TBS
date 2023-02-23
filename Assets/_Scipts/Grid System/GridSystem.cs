using UnityEngine;



public class GridSystem
{
    private readonly int width;
    private readonly int height;
    private readonly float cellSize;
    private readonly Grid[,] gridArray;
    
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new Grid[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var gridPosition = new GridPosition(x, z);
                var grid = new Grid(this, gridPosition);
                
                gridArray[x, z] = grid;
            }
        }
    }

    public Vector3 WorldFromGrid(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GripFromWorld(Vector3 worldPosition)
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
                
                gridDebugObj.MyGrid = GetGrid(gridPos);
            }
        }
    }

    public Grid GetGrid(GridPosition gridPosition)
    {
        return gridArray[gridPosition.x, gridPosition.z];
    }
    
}
