using System;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] private GridVisualSingle gridVisualSinglePrefab;

    public static GridSystemVisual Instance;
    
    private GridVisualSingle[,] gridVisualSingleArray;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gridVisualSingleArray = new GridVisualSingle[LevelGrid.Instance.GetWidth(), LevelGrid.Instance.GetHeight()];
        
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                var gridPos = new GridPosition(x, z);
                var a = Instantiate(gridVisualSinglePrefab, LevelGrid.Instance.WorldFromGrid(gridPos), Quaternion.identity);
                gridVisualSingleArray[x, z] = a;
            }
        }
    }


    private void Update()
    {
        UpdateGridVisual();
    }

    public void HideAllGridVisuals()
    {
        foreach (var gridVisual in gridVisualSingleArray)
        {
            gridVisual.Hide();
        }
    }

    public void ShowMovableGridVisuals(List<GridPosition> movables)
    {
        HideAllGridVisuals();
        
        foreach (var movable in movables)
        {
            gridVisualSingleArray[movable.x, movable.z].Show();   
        }
    }

    private void UpdateGridVisual()
    {
        var selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        ShowMovableGridVisuals(selectedUnit.GetMoveAction().GetValidGridPositionList());
    }
}
