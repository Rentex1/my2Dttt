
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public int damage = 10;
    public LineRenderer lineRenderer;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            StartCoroutine(Shoot());
        }
        
    }
    IEnumerator Shoot()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
}
