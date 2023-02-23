using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    
    public Grid MyGrid
    {
        get => myGrid;
        set
        {
            myGrid = value;
            text.text = myGrid.ToString();
        }
    }

    

    private Grid myGrid;


}
