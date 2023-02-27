using UnityEngine;

public class GridVisual : MonoBehaviour
{
    [SerializeField] private GridVisualSingle gridVisualSinglePrefab;


    private void Start()
    {
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                var gridPos = new GridPosition(x, z);
                Instantiate(gridVisualSinglePrefab, LevelGrid.Instance.WorldFromGrid(gridPos), Quaternion.identity);
            }
        }
    }
}
