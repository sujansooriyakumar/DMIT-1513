using UnityEngine;

public class MovingGameobject : MonoBehaviour
{
    public Vector3 maxMoveRange;
    public float moveSpeed;
    private Vector3 startingPosition;
    private Vector3 moveDir = Vector3.right;
    private Rigidbody rb; 
    private void Start()
    {
        startingPosition = transform.position;
        moveDir = maxMoveRange.normalized;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition =  transform.position + moveDir * moveSpeed * Time.deltaTime;
        Vector3 offset = nextPosition - startingPosition;

        if (Mathf.Abs(offset.x) > maxMoveRange.x ||
            Mathf.Abs(offset.y) > maxMoveRange.y ||
            Mathf.Abs(offset.z) > maxMoveRange.z)
        {
            moveDir *= -1;
            nextPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;

        }
        rb.MovePosition(nextPosition);
        
    }
}
