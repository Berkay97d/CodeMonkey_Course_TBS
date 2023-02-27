using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualSingle : MonoBehaviour
{
    [SerializeField] private GameObject visual;


    public void Show()
    {
        visual.SetActive(true);
    }

    public void Hide()
    {
        visual.SetActive(false);
    }
}
