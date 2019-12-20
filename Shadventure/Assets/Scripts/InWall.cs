using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("OnTriggerStay!!!!!!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("OnTriggerEnter!!!!!!");
        }
    }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if(other.tag == "Player")
    //     {
    //         Debug.Log("OnTriggerStay!!!!!!");
    //     }
    // }
}
