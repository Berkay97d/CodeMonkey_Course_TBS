using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;
    private BaseAction action;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            UnitActionSystem.Instance.selectedAction = action;
        });
    }

    public void SetBaseAction(BaseAction action)
    {
        text.text = action.GetActionName().ToUpper();
        this.action = action;
    }

    
}
