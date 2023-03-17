using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    private Camera mainCamera;
    private bool shootButtonDown = false;
    

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootButtonPressed { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootButtonReleased { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();

        GetPointerInput();

        GetShootInput();
    }

    private void GetShootInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0) 
        {
            if (shootButtonDown == false)
            {
                shootButtonDown = true;
                OnShootButtonPressed?.Invoke();
            }
        }
        else
        {
            if (shootButtonDown == true)
            {
                shootButtonDown = false;
                OnShootButtonReleased?.Invoke();
            }
        }

    }

    private void GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        var pointer = mainCamera.ScreenToWorldPoint(mousePos);
        OnPointerPositionChange?.Invoke(pointer);


    }

    private void GetMovementInput()
    {


        OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

    }
}
