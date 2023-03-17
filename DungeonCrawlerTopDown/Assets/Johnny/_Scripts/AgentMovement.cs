using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody;

    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }

    [SerializeField]
    protected float currentSpeed = 6f;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();


    }

    public void MoveAgent(Vector2 movementInput)
    {
        movementDirection = movementInput;
        currentSpeed = CalculateSpeed(movementInput);

        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }
        currentSpeed = CalculateSpeed(movementInput);

    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentSpeed += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= MovementData.deacceleration * Time.deltaTime;

        }
        return Math.Clamp(currentSpeed, 0, MovementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentSpeed);
        rigidbody.velocity = currentSpeed * movementDirection.normalized;


    }
}
