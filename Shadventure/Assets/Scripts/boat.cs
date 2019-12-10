using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    public GameObject myShadow;
    
    private float triggerY = 0.75f;
    private float stopX = -3.9f;
    private float thrust = 100.0f;
    private float shipSpeed = 2.0f;
    private bool floatingForceOn = false;

    private Rigidbody2D ship01Rigidbody;
    private Collider2D ship01Collider;
    private Collider2D shadowCollider;
    private Vector2 floatingForce;
    private Vector2 floatingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ship01Rigidbody = GetComponent<Rigidbody2D>();
        ship01Collider = GetComponent<PolygonCollider2D>();
        shadowCollider = myShadow.GetComponent<PolygonCollider2D>();
        if(shadowCollider == null)
        {
            Debug.Log("shadowCollider is null!!!! \n");
        }
        floatingForce = new Vector2(0, 3);
        floatingSpeed = new Vector2(0, 2);
        ship01Rigidbody.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        ship01Rigidbody.constraints = UnityEngine.RigidbodyConstraints2D.FreezePositionX;

        Physics2D.IgnoreCollision(ship01Collider, shadowCollider);

        Vector3 startPoint = new Vector3(-8.0f, -3.5f, 0);
        transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= triggerY)
        {
            ship01Rigidbody.velocity = shipSpeed * transform.right;
            if(transform.position.x >= stopX)
            {
                ship01Rigidbody.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
            }
        }
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {   
        ship01Rigidbody.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        if(Physics2D.GetIgnoreCollision(ship01Collider, shadowCollider))
        {
            Debug.Log("--- collision between shadow & boat is ignored \n");
        }

        Collider2D collidee = collision.collider; 
        if(collision.gameObject.tag == "Metaball_liquid")
        {
            //Debug.Log("contacting with water ---- \n");
            //Physics2D.IgnoreCollision(ship01Collider, collidee, true);
            ship01Rigidbody.velocity = floatingSpeed*transform.up;
            //collision.enabled = false;
            //Vector3 impulse = collision.impulse;
            //ship01Rigidbody.AddForce(-impulse, ForceMode.Impulse);//refrain the boat from colliding impulses
        }  
        // if(collision.gameObject.tag == "Player")
        // {
        //     Debug.Log("ship01 colliding with player ---- \n");
        // }      
    }




}
