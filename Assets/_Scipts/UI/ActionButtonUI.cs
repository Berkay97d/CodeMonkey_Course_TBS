using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;

    public void SetBaseAction(BaseAction action)
    {
        text.text = action.GetActionName().ToUpper();
    }
        
}
