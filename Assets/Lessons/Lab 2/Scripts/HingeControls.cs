using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HingeControls : MonoBehaviour
{
    public InputAction rotate;
    private HingeJoint hinge;

    private float rotationDirection = 0f;
    public float rotationSpeed = 1f;

    public UnityEvent OnRotate;
    public UnityEvent OnStopRotate;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        rotate.Enable();
        rotate.performed += RotateInput;
        rotate.canceled += RotateInput;
    }

    private void RotateInput(InputAction.CallbackContext c)
    {
        rotationDirection = c.ReadValue<float>();
        if (rotationDirection != 0) OnRotate?.Invoke();
        else { OnStopRotate?.Invoke(); }

        JointMotor motor = hinge.motor;
        motor.targetVelocity = rotationDirection * rotationSpeed;
        hinge.motor = motor;
    }


}
