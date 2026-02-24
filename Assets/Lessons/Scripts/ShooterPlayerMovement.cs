using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayerMovement : MonoBehaviour
{
    public InputAction movementInput;
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
        animator.SetBool("isWalking", moveVector.y > 0);
        animator.SetBool("isStrafing", Mathf.Abs(moveVector.x) > 0);
        animator.SetBool("isWalkingBack", moveVector.y < 0);
        
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition += new Vector3(moveVector.x, 0, moveVector.y) * movementSpeed * Time.deltaTime;
        rb.Move(newPosition, transform.rotation);
    }
}
