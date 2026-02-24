using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public abstract class Gun : MonoBehaviour
{
    public int magazineSize;
    public int ammoCount;
    public float fireRate;
    public float dmg;
    public Transform bulletSpawnLocation;
    public AudioClip fireSFX;
    public GameObject hitFX;

    public abstract void Shoot();

    public abstract void StopShooting();

    public abstract void Reload();
}
