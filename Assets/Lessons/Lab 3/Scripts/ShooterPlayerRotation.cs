using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayerRotation : MonoBehaviour
{
    public InputAction rotationInput;
    public float sensitivity = 0.1f;
    private float yaw, pitch;
    public float maxPitch;
    public Transform spine;


    private void Start()
    {
        rotationInput.Enable();
        rotationInput.performed += OnLook;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnLook(InputAction.CallbackContext c)
    {
        Vector2 mouseDelta = c.ReadValue<Vector2>();

        yaw += mouseDelta.x * sensitivity;
        pitch -= mouseDelta.y * sensitivity;
    }

    public void LateUpdate()
    {
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);
        if (GetComponent<CameraController>().currentState == CameraState.FIRST_PERSON)
        {

            //Quaternion rotationOffset = Quaternion.Euler(pitch, yaw, 0);
            transform.rotation = Quaternion.Euler(pitch, yaw, 0);
            // spine.rotation = Quaternion.Euler(pitch, yaw, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, yaw, 0);
             spine.rotation = Quaternion.Euler(pitch, yaw, 0);
        }
    }

}
