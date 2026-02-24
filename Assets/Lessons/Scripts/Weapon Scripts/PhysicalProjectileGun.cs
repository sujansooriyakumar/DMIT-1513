using System.Collections;
using UnityEngine;

public class PhysicalProjectileGun : Gun
{
    public GameObject projectilePrefab;
    private bool canFire = true;
    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        // fire the projectile
        // set canfire = false
        // start the coroutine
        if (canFire)
        {
            GameObject tmp = Instantiate(projectilePrefab, bulletSpawnLocation.position, Quaternion.identity);
            Projectile p = tmp.GetComponent<Projectile>();
            p.SetProjectileDamage(dmg);
            p.ApplyProjectileForce();
            p.OnHit += ProjectileHit;
            GetComponent<AudioSource>().PlayOneShot(fireSFX);
            canFire = false;
            StartCoroutine(FireDelay());
        }
    }

    private void ProjectileHit(Vector3 hitLocation)
    {
        Instantiate(hitFX, hitLocation, Quaternion.identity);
    }

    public override void StopShooting()
    {
    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
