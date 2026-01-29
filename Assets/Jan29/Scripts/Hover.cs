using UnityEngine;

public class Hover : MonoBehaviour
{
    public float antiGravForce;
    private Rigidbody rb;
    RaycastHit hit;
    public float distanceFromGround;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        antiGravForce = rb.mass;

        if(Physics.BoxCast(transform.position + new Vector3(0,transform.localScale.y/2,0),
            GetComponent<BoxCollider>().bounds.extents, Vector3.down, out hit, transform.rotation, distanceFromGround))
        {
            rb.AddForce(transform.up * (distanceFromGround - hit.distance) / distanceFromGround * antiGravForce, ForceMode.Impulse);

        }
    }
}
