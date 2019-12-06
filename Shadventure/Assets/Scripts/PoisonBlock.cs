using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBlock : MonoBehaviour
{
    public Transform spawnPosition;

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player touch the poison brick");
        playerTransform.position = spawnPosition.position;
        // if(col.gameObject.tag == "Player")
        // {
        //     Debug.Log(col.gameObject.tag);
        // }
        //Destroy (this.gameObject);
        
    }

}
