using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float zoomAmount;
    [SerializeField] private float minZoomY;
    [SerializeField] private float maxZoomY;
    [SerializeField] private float smoothMultiplier;
    [SerializeField] private float newSelectedUnitLerpTime;
    

    private Vector3 rotationVector = Vector3.zero;
    private Vector3 inputMoveDirection = Vector3.zero;
    private bool isOnAnimation = false;
    
    private float ShiftMoveSpeed => moveSpeed * 2.5f;
    private float ShiftRotateSpeed => rotationSpeed * 2.5f;
    

    private void Start()
    {
        camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, 10, -10);
        
        UnitSelectionSystem.Instance.OnSelectedUnitChanged += InstanceOnOnSelectedUnitChanged;
    }

    private void InstanceOnOnSelectedUnitChanged(object sender, UnitSelectionSystem.OnSelectedUnitChangedEventArgs e)
    {
        isOnAnimation = true;
        transform.DOMove(e.NewUnit.transform.position, newSelectedUnitLerpTime).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            isOnAnimation = false;
        });
    }

    private void Update()
    {
        if (isOnAnimation) return;
        
        ControlCameraPosition();
        HandleCameraRotation();
        ControlZoomIn();
    }

    private void ControlCameraPosition()
    {
        inputMoveDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x = +1f;
        }
        

        var moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
        var inputNormalized = moveVector.normalized;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += inputNormalized * ShiftMoveSpeed * Time.deltaTime;
            return;
        }
        
        transform.position += inputNormalized * moveSpeed * Time.deltaTime;
        
        
    }

    private void HandleCameraRotation()
    {
        rotationVector = Vector3.zero;
        
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.eulerAngles += rotationVector * ShiftRotateSpeed * Time.deltaTime;
            return;
        }

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

    private void ControlZoomIn()
    {

        var cinemachineTranzposer = camera.GetCinemachineComponent<CinemachineTransposer>();
        var followOffset = cinemachineTranzposer.m_FollowOffset;
        
        if (Input.mouseScrollDelta.y > 0 && followOffset.y > minZoomY)
        {
            followOffset.y -= zoomAmount;
            followOffset.z += zoomAmount / 1.5f;
        }
        if (Input.mouseScrollDelta.y < 0 && followOffset.y < maxZoomY)
        {
            followOffset.y += zoomAmount;
            followOffset.z -= zoomAmount / 1.5f;
        }

        cinemachineTranzposer.m_FollowOffset =
            Vector3.Lerp(cinemachineTranzposer.m_FollowOffset, followOffset, Time.deltaTime * smoothMultiplier);
    }
}
