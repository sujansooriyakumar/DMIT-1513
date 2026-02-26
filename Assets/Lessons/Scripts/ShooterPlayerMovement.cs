using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayerMovement : MonoBehaviour
{
    public InputAction movementInput;
    public CameraController cameraController;
    private Vector2 moveVector;
    private Rigidbody rb;
    private Animator animator;
    public float movementSpeed;
    

    private void Awake()
    {
        movementInput.Enable();
        movementInput.performed += ReadMoveInput;
        movementInput.canceled += ReadMoveInput;

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (cameraController.currentState == CameraState.THIRD_PERSON)
        {
            animator.SetBool("isWalking", moveVector.y > 0);
            // animator.SetBool("isStrafing", Mathf.Abs(moveVector.x) > 0);
            animator.SetBool("isWalkingBack", moveVector.y < 0);
        }
        
    }


    private void Update()
    {
        
        Vector3 moveDirection = (transform.forward * moveVector.y) + (transform.right * moveVector.x);

        Vector3 deltaMovement = moveDirection * movementSpeed * Time.deltaTime;

        rb.Move(transform.position + deltaMovement, transform.rotation);
    }

}
