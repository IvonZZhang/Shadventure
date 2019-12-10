using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;

public class cloudRaining : MonoBehaviour
{
    public float cloudSpeed = 10.0f;
    public GameObject myPipe;
    public Water2D_Spawner myPipeScript;

    private float boundary = 10.0f;
    private float height = 3.5f;
    private Rigidbody2D cloudRigidbody2d;
    private Vector3 Point1;
    private Vector3 Point2;
    
    // Start is called before the first frame update
    void Start()
    {
        cloudRigidbody2d = GetComponent<Rigidbody2D>();
        Point1 = new Vector3(-boundary, height, 0);
        Point2 = new Vector3(boundary, height, 0);
        Vector3 startPoint = new Vector3(-boundary-20, height, 0);

        transform.position = startPoint;
        myPipe.transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {   
        myPipe.transform.position = transform.position + new Vector3(0.5f, -0.5f, 0);
        
        if(transform.position.x < Point1.x)
        {
            cloudRigidbody2d.velocity = cloudSpeed * transform.right;
            myPipeScript.Restore();
        }
        else if(transform.position.x > Point2.x)
        {
            cloudRigidbody2d.velocity = -cloudSpeed * transform.right;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "tilemapTag")
        {
            Debug.Log("cloud02 colliding with tilemap ---- \n");

        }
        else if(collision.gameObject.tag == "Player")
        {
            Debug.Log("cloud02 colliding with player ---- \n");
            myPipeScript.Spawn();
            cloudRigidbody2d.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;
        }
        
    }



}
