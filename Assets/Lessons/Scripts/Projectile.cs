using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
    public float projectileForce;
    private Rigidbody rb;
    private float projectileDamage;
    public AudioClip onHitSFX;
    public event Action<Vector3> OnHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetProjectileDamage(float damage)
    {
        projectileDamage = damage;
    }
    public void ApplyProjectileForce()
    {
        rb.AddForce(transform.forward * projectileForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() == null) return;
        collision.gameObject.GetComponent<IDamagable>().TakeDamage(projectileDamage);
        GetComponent<AudioSource>().PlayOneShot(onHitSFX);
        OnHit?.Invoke(transform.position);
    }
}
