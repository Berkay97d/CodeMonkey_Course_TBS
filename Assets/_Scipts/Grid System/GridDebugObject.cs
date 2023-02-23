using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    public GridObject MyGridObject
    {
        get => myGridObject;
        set
        {
            myGridObject = value;
            text.text = myGridObject.ToString();
        }
    }

    private GridObject myGridObject;


}
