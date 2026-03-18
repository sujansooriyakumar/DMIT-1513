using UnityEngine;
using UnityEngine.Events;

public class CollisionEventHandler : MonoBehaviour
{
    public string tagToCheck;
    public UnityEvent OnCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(tagToCheck)) return;
        OnCollision?.Invoke();
    }
}
