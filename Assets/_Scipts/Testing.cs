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
                unit.GetMoveAction().GetValidGridPositionList();
            }
        }
    }
}