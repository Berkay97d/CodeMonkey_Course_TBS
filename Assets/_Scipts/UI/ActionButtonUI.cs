using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;    
    [SerializeField] private Button button;
    [SerializeField] private Transform selectedVisual;
    
    
    private BaseAction action;

    
    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            UnitActionSystem.Instance.SetSelectedAction(action);
        });
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(() =>
        {
            UnitActionSystem.Instance.SetSelectedAction(action); 
        });
    }

    public void SetBaseAction(BaseAction action)
    {
        text.text = action.GetActionName().ToUpper();
        this.action = action;
    }

    public void UpdateSelectedVisual()
    {
        selectedVisual.gameObject.SetActive(UnitActionSystem.Instance.GetSelectedAction() == action);
    }
    

}
