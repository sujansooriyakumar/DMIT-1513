using System.Collections;
using UnityEngine;

public class RaycastGun : Gun
{
    private bool isFiring = false;
    
    public override void Reload()
    {
    }

    public override void Shoot()
    {
        isFiring = true;
        StartCoroutine(FireCoroutine());
    }

    public override void StopShooting()
    {
        isFiring = false;
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            RaycastHit hit;
            Physics.Raycast(bulletSpawnLocation.position, bulletSpawnLocation.forward, out hit, Mathf.Infinity);
            GetComponent<AudioSource>().PlayOneShot(fireSFX);
            Debug.DrawRay(bulletSpawnLocation.position, bulletSpawnLocation.forward, Color.red, 3.0f);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<IDamagable>().TakeDamage(dmg);
            }
            yield return new WaitForSeconds(fireRate);
        }
        yield return null;
    }
}
