using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float unitSpeed;
    [SerializeField] private float stopingTreshold;

    private Vector3 targetPosition;


    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stopingTreshold)
        {
            var moveDir = (targetPosition - transform.position).normalized;
            transform.position += moveDir * unitSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) <= stopingTreshold)
            {
                transform.position = Vector3Extention.Round(transform.position);    
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(new Vector3(10, 0, 10), unitSpeed);
        }
    }


    private void Move(Vector3 targetPos, float speed)
    {
        targetPosition = targetPos;
    }



}
