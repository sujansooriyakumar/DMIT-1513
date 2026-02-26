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
            Ray screenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Vector3 aimPoint;

            if(Physics.Raycast(screenRay, out RaycastHit screenHit, Mathf.Infinity))
            {
                aimPoint = screenHit.point;
            }
            else
            {
                aimPoint = screenRay.GetPoint(100f);
            }

            Vector3 shootDirection = (aimPoint - bulletSpawnLocation.position).normalized;
            Debug.DrawRay(bulletSpawnLocation.position, shootDirection, Color.red, 3.0f);

            if (Physics.Raycast(bulletSpawnLocation.position, shootDirection, out hit, Mathf.Infinity))
            {

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<IDamagable>() != null)
                    {
                        hit.collider.gameObject.GetComponent<IDamagable>().TakeDamage(dmg);
                    }
                }
            }


            GetComponent<AudioSource>().PlayOneShot(fireSFX);
            
            yield return new WaitForSeconds(fireRate);
        }
        yield return null;
    }
}
