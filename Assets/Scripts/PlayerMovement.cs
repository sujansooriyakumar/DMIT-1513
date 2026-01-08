using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction movementAction;
    Transform t;
    Vector3 movementVector;
    public float moveSpeed = 1.0f;

    private void Start()
    {
        movementVector = Vector3.zero;
        movementAction.Enable();
        t = GetComponent<Transform>();
        movementAction.performed += MoveCharacter;
        movementAction.canceled += MoveCharacter;
    }

    private void MoveCharacter(InputAction.CallbackContext context)
    {
        var tmp = context.ReadValue<Vector2>();
        movementVector = new Vector3(tmp.x, 0, tmp.y);
    }

    private void FixedUpdate()
    {
        // transform: holds the player position
        // movementVector: holds the movement direction
        t.position += movementVector * moveSpeed * Time.deltaTime;
    }

    
}
