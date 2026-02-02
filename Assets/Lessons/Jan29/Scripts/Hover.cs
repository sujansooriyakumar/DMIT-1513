using UnityEngine;
using UnityEngine.InputSystem;

public class Hover : MonoBehaviour
{
    public float antiGravForce;
    private Rigidbody rb;
    RaycastHit hit;
    public float distanceFromGround;
    float hoverMod;
    float hoverDecellerate = -0.25f;
    public InputAction hover;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        hover.Enable();
        hover.performed += HoverInput;
        hover.canceled += HoverInput;
    }

    public void HoverInput(InputAction.CallbackContext c)
    {
        hoverMod = c.ReadValue<float>()/2f;
    }

    private void FixedUpdate()
    {
        antiGravForce = rb.mass;
        distanceFromGround += hoverMod + hoverDecellerate;
        distanceFromGround = Mathf.Clamp(distanceFromGround, 0.0f, Mathf.Infinity);
        if(Physics.BoxCast(transform.position + new Vector3(0,transform.localScale.y/2,0),
            GetComponent<BoxCollider>().bounds.extents, Vector3.down, out hit, transform.rotation, distanceFromGround))
        {
            rb.AddForce(transform.up * (distanceFromGround - hit.distance) / distanceFromGround * antiGravForce, ForceMode.Impulse);

        }
    }
}
