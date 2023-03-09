using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 10f;
    public Rigidbody2D rigidBody;
    public PlayerInputActions playerControls;
    public Animator animator;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction fire;

    public float testMove;

    public float dashDistance = 300f;


    private void Awake()
    {
        //playerControls = new PlayerInputActions();


    }

    //private void OnEnable()
    //{
    //    move = playerControls.Player.Move;
    //    move.Enable();

    //    fire = playerControls.Player.Fire;
    //    fire.Enable();
    //    // register the fire method to the event
    //    fire.performed += Fire; 



    //}

    //private void OnDisable()
    //{
    //    move.Disable();
    //    fire.Disable();

    //}


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    float horizontalMove = 0f;
    float verticalMove = 0f;
    Vector2 movement;

    void Update()
    {
        // input

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");



        animator.SetFloat("Horizontal", movement.x);

        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));

        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            float dashSide = animator.GetFloat("LastMoveX");
            float dashUpDown = animator.GetFloat("LastMoveY");
            if (dashSide == 1 || dashSide == -1)
            {
                StartCoroutine(Dashingg(dashSide));

            }
            else if (dashUpDown == 1 || dashUpDown == -1)
            {
                StartCoroutine(Dashingg(dashUpDown));
            }


        }

        //moveDirection = move.ReadValue<Vector2>();

        Dash();

    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsDashing", true);
            testMove = 50f;
            rigidBody.MovePosition(rigidBody.position + movement.normalized * testMove * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("IsDashing", false);
            testMove = 5f;

        }

    }

    private void FixedUpdate()
    {
        // Movement

        //rigidBody.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);

        if (!animator.GetBool("IsDashing"))
        {
            testMove = 5f;
            rigidBody.MovePosition(rigidBody.position + movement.normalized * testMove * Time.fixedDeltaTime);
        }



    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Test fire");
    }

    private void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //animator.SetBool("IsDashing", true);

            //rigidBody.AddForce(new Vector2(dashDistance * directionX, dashDistance * directionY), ForceMode2D.Impulse);
            //yield return new WaitForSeconds(0.2f);

            //animator.SetBool("IsDashing", false);

            float dashDistancee = 1000f;
            //rigidBody.AddForce(new Vector2(movement.x * dashDistancee, movement.y * dashDistancee), ForceMode2D.Impulse);

            float dashY = animator.GetFloat("LastMoveY") * 500f;
            float dashX = animator.GetFloat("LastMoveX") * 500f;

            rigidBody.MovePosition(new Vector2(rigidBody.position.x + dashX, rigidBody.position.y + dashY));
        }
    }

    IEnumerator Dashingg (float direction)
    {
        float dashY = animator.GetFloat("LastMoveY") * 300f;
        float dashX = animator.GetFloat("LastMoveX") * 300f;

        animator.SetBool("IsDashing", true);
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y);
        rigidBody.AddForce(new Vector2(dashX * direction, dashY * direction), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);

        animator.SetBool("IsDashing", true);

    }

}
