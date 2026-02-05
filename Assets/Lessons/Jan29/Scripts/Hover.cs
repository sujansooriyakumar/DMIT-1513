using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Hover : MonoBehaviour
{
    [Header("Hover Heights")]
    public float baseHoverHeight = 1.2f;
    public float maxHoverHeight = 6f;
    public float riseSpeed = 2.5f;

    [Header("Hover Physics")]
    public float springStrength = 60f;
    public float damping = 10f;

    [Header("Input")]
    public InputAction hover;

    Rigidbody rb;
    Collider col;

    float targetHoverHeight;
    float hoverHeld;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        targetHoverHeight = baseHoverHeight;
    }

    void OnEnable()
    {
        hover.Enable();
        hover.performed += OnHover;
        hover.canceled += OnHover;
    }

    void OnDisable()
    {
        hover.performed -= OnHover;
        hover.canceled -= OnHover;
        hover.Disable();
    }

    void OnHover(InputAction.CallbackContext ctx)
    {
        hoverHeld = ctx.ReadValue<float>(); // 1 held, 0 released
    }

    void FixedUpdate()
    {
        // Adjust target hover height
        if (hoverHeld > 0f)
        {
            targetHoverHeight += riseSpeed * Time.fixedDeltaTime;
            targetHoverHeight = Mathf.Clamp(targetHoverHeight, baseHoverHeight, maxHoverHeight);
        }
        else
        {
            targetHoverHeight = baseHoverHeight;
        }

        Vector3 origin = transform.position + Vector3.up * col.bounds.extents.y;

        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, targetHoverHeight))
        {
            float currentHeight = hit.distance;
            float error = targetHoverHeight - currentHeight;

            float verticalVelocity = Vector3.Dot(rb.linearVelocity, Vector3.up);

            float force =
                (error * springStrength)
                - (verticalVelocity * damping);

            // Cancel gravity explicitly
            if (hoverHeld > 0f)
            {
                force += rb.mass * Physics.gravity.magnitude;
                rb.AddForce(Vector3.up * force, ForceMode.Force);
            }

        }
    }
}
