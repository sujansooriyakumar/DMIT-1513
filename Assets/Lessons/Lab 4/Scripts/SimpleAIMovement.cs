using UnityEngine;

public class SimpleAIMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Vector3 direction;
    public Transform player;

 
    public void Move()
    {
        rb = GetComponent<Rigidbody>();
        direction = player.position - transform.position;
        Vector3 tmp = new Vector3(direction.x, 0, direction.z);
        rb.linearVelocity = tmp.normalized * speed;
    }
}
