using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class cloudRaining : MonoBehaviour
{
    
    public GameObject myShadow;
    public Water2D_Spawner myPipeScript;
    public Transform myLevelTrans;
    public GameObject myLevel;

    [SerializeField]
    private float cloudSpeed = 7.0f;
    private float boundary1 = -17.0f;
    private float boundary2 = 9.0f;
    private float height = 6.0f;

    private Rigidbody2D cloudRigidbody2d;
    private Vector2 prevVelocity;
    private Vector3 Point1;
    private Vector3 Point2;

    private bool flag = false;
    private bool spawning = false;
    private int count;
    private int direction;
    
    // Start is called before the first frame update
    void Start()
    {
        cloudRigidbody2d = GetComponent<Rigidbody2D>();
        Point1 = new Vector3(myLevelTrans.position.x+boundary1, myLevelTrans.position.y+height, 0);
        Point2 = new Vector3(myLevelTrans.position.x+boundary2, myLevelTrans.position.y+height, 0);
        Vector3 startPoint = new Vector3(myLevelTrans.position.x+boundary1-1, myLevelTrans.position.y+height, 0);

        //cloudRigidbody2d.useFullKinematicContacts = true;
        transform.position = startPoint;
        GetComponent<PolygonCollider2D>().isTrigger = true;
        myShadow.GetComponent<PolygonCollider2D>().isTrigger = true;

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(myPipeScript.finished && !flag)
        {
            flag = true;
            spawning = false;
            Debug.Log("raining finished! \n");
            GetComponent<PolygonCollider2D>().isTrigger = true;
            myShadow.GetComponent<PolygonCollider2D>().isTrigger = true;
            cloudRigidbody2d.constraints = UnityEngine.RigidbodyConstraints2D.FreezePositionY | UnityEngine.RigidbodyConstraints2D.FreezeRotation;
            if(direction == 1)
            {
                cloudRigidbody2d.velocity = cloudSpeed * transform.right;
            }
            else if(direction == 2)
            {
                cloudRigidbody2d.velocity = -cloudSpeed * transform.right;
            }
            
        }
        if(transform.position.x < Point1.x)
        {
            cloudRigidbody2d.velocity = cloudSpeed * transform.right;
            direction = 1;
            //myPipeScript.Restore();
        }
        else if(transform.position.x > Point2.x)
        {
            cloudRigidbody2d.velocity = -cloudSpeed * transform.right;
            direction = 2;
            //myPipeScript.Restore();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shadow")
        {    
            count ++;
            Debug.Log("trigerred *1\n");
        }
        
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if((count%3) == 0)
        {
            GetComponent<PolygonCollider2D>().isTrigger = false;
            myShadow.GetComponent<PolygonCollider2D>().isTrigger = false;
            Debug.Log("isTrigger = false \n");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        count++;
        if(collision.gameObject.tag == "Shadow" & !spawning)
        {
            Debug.Log("cloud colliding VALID \n");
            myPipeScript.Restore();
            myPipeScript.Spawn();
            spawning = true;
            cloudRigidbody2d.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
            //GetComponent<PolygonCollider2D>().isTrigger = true;
            flag = false;
        }
        
    }



}
