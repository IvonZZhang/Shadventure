using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat_temp : MonoBehaviour
{
    public GameObject myShadow;
    public Transform myLevel;
    public boatTrigger myBoatTriggerScript;
    public CircleCollider2D playerCollider;

    //public boat_temp nextBoatScript;
    //public boatTrigger nextBoatTriggerScript;
    //public int boatNumber;

    private Rigidbody2D boat_rigidBody2D;

    public float triggerHeight;
    public float stopX;
    public float startX;
    public float startY;

    private float shipSpeedX;
    public float shipSpeedY;
    
    private bool playerOn;
    private bool flag;
    private bool flag2;


    // Start is called before the first frame update
    void Start()
    {
        init();
        
    }

    private void init()
    {
        //nextBoatScript.enabled = false;
        //nextBoatTriggerScript.enabled = false;

        shipSpeedX = 2.0f;
        playerOn = false;
        flag = false;
        flag2 = true;

        boat_rigidBody2D = GetComponent<Rigidbody2D>();
        boat_rigidBody2D.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation | UnityEngine.RigidbodyConstraints2D.FreezePositionX;

        Vector3 startPoint = new Vector3(myLevel.position.x+startX, myLevel.position.y+startY, 0);
        transform.position = startPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myBoatTriggerScript.waterTouching & !flag)
        {
            Debug.Log("boat going up \n");
            boat_rigidBody2D.velocity = shipSpeedY * transform.up;
        }

        if(transform.position.y >= myLevel.position.y + triggerHeight & flag2)
        {
            flag = true;
            Debug.Log("boat going right \n");
            boat_rigidBody2D.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation | UnityEngine.RigidbodyConstraints2D.FreezePositionY;
            boat_rigidBody2D.velocity = shipSpeedX * transform.right;
        }

        if (transform.position.x >= myLevel.position.x + stopX)
        {
            flag2 = false;
            boat_rigidBody2D.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
            GetComponent<PolygonCollider2D>().sharedMaterial.friction = 4.0f;
            if (!myBoatTriggerScript.waterTouching & !GetComponent<PolygonCollider2D>().IsTouching(playerCollider))//restarting
            {
                Debug.Log("restarting boat!!! \n");
                myBoatTriggerScript.init();
                init();
                //nextBoatScript.enabled = true;
                //nextBoatTriggerScript.enabled = true;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOn = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOn = false;

        }
    }


}
