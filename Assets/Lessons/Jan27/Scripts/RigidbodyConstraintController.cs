using UnityEngine;

public class RigidbodyConstraintController : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetRotationConstraintX() { rb.constraints = RigidbodyConstraints.FreezeRotationX;}

    public void SetRotationConstraintY() { rb.constraints = RigidbodyConstraints.FreezeRotationY; }

    public void SetRotationConstraintZ() { rb.constraints = RigidbodyConstraints.FreezeRotationZ; }

    public void SetPositionConstraintX() { rb.constraints = RigidbodyConstraints.FreezePositionX; }
    public void SetPositionConstraintY() { rb.constraints = RigidbodyConstraints.FreezePositionY; }
    public void SetPositionConstraintZ() { rb.constraints = RigidbodyConstraints.FreezePositionZ; }

    public void SetAllRotationConstraints() { rb.constraints = RigidbodyConstraints.FreezeRotation; }

    public void SetAllPositionConstraints() { rb.constraints = RigidbodyConstraints.FreezePosition; }

    public void SetAllConstraints() { rb.constraints = RigidbodyConstraints.FreezeAll; }
    public void ResetConstraints() { rb.constraints = RigidbodyConstraints.None; } 
       
}
