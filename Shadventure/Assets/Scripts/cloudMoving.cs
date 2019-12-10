using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMoving : MonoBehaviour
{
    public float cloudSpeed = 15.0f;

    private float boundary = 12.0f;
    private float height = 4.3f;
    private Rigidbody2D cloudRigidbody2d;
    private Vector3 Point1;
    private Vector3 Point2;
    
    // Start is called before the first frame update
    void Start()
    {
        cloudRigidbody2d = GetComponent<Rigidbody2D>();
        Point1 = new Vector3(boundary, height, 0);
        Point2 = new Vector3(-boundary, height, 0);
        Vector3 startPoint = new Vector3(boundary+2, height, 0);

        transform.position = startPoint;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(transform.position.x > Point1.x)
        {
            cloudRigidbody2d.velocity = -cloudSpeed * transform.right;
        }
        else if(transform.position.x < Point2.x)
        {
            cloudRigidbody2d.velocity = cloudSpeed * transform.right;
        }
    }

}
