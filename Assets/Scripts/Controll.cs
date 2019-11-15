using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controll : NetworkBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    public float moveSpeed = 5;
    public Camera cam;

    Vector2 movement;
    public Vector2 mousePos;
    
   
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 direction = mousePos - rb2d.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 10f;
        rb2d.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    { 
        if(!isLocalPlayer)
    {
        return;
    }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
}
