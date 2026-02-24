using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagable
{
    public float hp = 10f;
    public UnityEvent OnDeath;
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
