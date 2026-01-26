using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleMovement : MonoBehaviour
{
    public InputAction movementAction;
    public InputAction rotationAction;
    public InputAction rotateArms;
    public InputAction rotateBucket;

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float armRotationSpeed = 1.0f;
    public float bucketRotationSpeed = 1.0f;

    float movementDirection;
    float rotationDirection;
    float armRotationDirection;
    float bucketRotationDirection;

    public float maxLinearSpeed;
    public float currentLinearSpeed;

    public float maxAngularSpeed;
    public float currentAngularSpeed;

    public float maxArmAngularSpeed;
    public float currentArmAngularSpeed;

    public float maxBucketAngularSpeed;
    public float currentBucketAngularSpeed;

    Rigidbody rb;
    public Rigidbody armRb;
    public Rigidbody bucketRB;

    private const float ACCELERATION_FACTOR = 20f;
    private const float ROTATION_FACTOR = 40f;
    void Start()
    {
        movementDirection = 0f;
        rotationDirection = 0f;
        rb = GetComponent<Rigidbody>();

        // velocity = rate of movement
        // acceleration = rate of increase of velocity

        movementAction.Enable();
        movementAction.performed += MoveVehicle;
        movementAction.canceled += MoveVehicle;

        rotationAction.Enable();
        rotationAction.performed += RotateVehicle;
        rotationAction.canceled += RotateVehicle;
    }
    private void MoveVehicle(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<float>() * ACCELERATION_FACTOR;
        
    }

    private void RotateVehicle(InputAction.CallbackContext context)
    {
        rotationDirection = context.ReadValue<float>() * ROTATION_FACTOR;
    }

    private void RotateArms(InputAction.CallbackContext context)
    {

    }


    private void RotateBucket(InputAction.CallbackContext context)
    {

    }

    private void FixedUpdate()
    {
        currentLinearSpeed = rb.linearVelocity.magnitude;
        currentAngularSpeed = rb.angularVelocity.magnitude;

        rb.AddForce(transform.forward * movementDirection, ForceMode.Acceleration);
        rb.AddTorque(Vector3.up * rotationDirection, ForceMode.Acceleration);
        //armRb.AddTorque()
        //bucketRB.AddTorque()
        if (currentLinearSpeed > maxLinearSpeed) rb.linearVelocity = rb.linearVelocity.normalized
                * maxLinearSpeed;
        if (currentAngularSpeed > maxAngularSpeed) rb.angularVelocity = rb.angularVelocity.normalized * maxAngularSpeed;
        
    }
}
