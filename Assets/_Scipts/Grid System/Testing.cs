using System;
using UnityEngine;

namespace _Scipts.Grid_System
{
    public class Testing : MonoBehaviour
    {
        private GridSystem gridSystem;
        [SerializeField] private Transform prefab;
            
        
        private void Start()
        {
            gridSystem = new GridSystem(10, 10, 1f);
            gridSystem.CreateDebugObjects(prefab);
        }
        
    }
}