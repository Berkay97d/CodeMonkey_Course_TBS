using System;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] private float spinAddAmount;
    
    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive) return;
        
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        totalSpinAmount += spinAddAmount;
        
        Debug.Log("ACTİVE");

        if (totalSpinAmount >= 360)
        {
            isActive = false;
        }
    }

    public void Spin()
    {
        isActive = true;
        totalSpinAmount = 0f;
    }
}
