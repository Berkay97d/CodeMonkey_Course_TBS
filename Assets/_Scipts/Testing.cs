using System;
using UnityEngine;

namespace _Scipts.Grid_System
{
    public class Testing : MonoBehaviour
    {
        [SerializeField] private Unit  unit;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GridSystemVisual.Instance.ShowMovableGridVisuals(unit.GetMoveAction().GetValidGridPositionList());
            }
        }
    }
}