
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public int damage = 10;
    public GameObject bullet;
    
    public float speed = 22f;
    
    
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            CmdShoot();
        }

        
    }
   [Command]
    void CmdShoot()
    {
        
        
        GameObject bulletObject = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
        NetworkServer.Spawn(bulletObject);
        Destroy(bulletObject, 2);
    }
}
