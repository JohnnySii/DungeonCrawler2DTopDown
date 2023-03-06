using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 5f;
    public Rigidbody2D rigidBody;
    public PlayerInputActions playerControls;
    public Animator animator;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction fire;

    private void Awake()
    {
        playerControls = new PlayerInputActions();


    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        // register the fire method to the event
        fire.performed += Fire; 



    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();

    }


    void Start()
    {
        
    }

    float horizontalMove = 0f;
    float verticalMove = 0f;

    void Update()
    {
        // input

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

        verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;



        animator.SetFloat("Speed", horizontalMove);

        animator.SetFloat("VerticalSpeed", verticalMove);




        moveDirection = move.ReadValue<Vector2>();


    }

    private void FixedUpdate()
    {
        // Movement

        rigidBody.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);


    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Test fire");
    }

}
