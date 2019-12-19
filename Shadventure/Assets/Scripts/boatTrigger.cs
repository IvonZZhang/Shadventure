using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatTrigger : MonoBehaviour
{

    public bool waterIn;
    public bool waterTouching;
    //public Collider2D waterCollider;
    // Start is called before the first frame update
    void Start()
    {
        init();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        waterIn = false;
        waterTouching = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Metaball_liquid")
        {
            waterIn = true;
            waterTouching = true;
        } 
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Metaball_liquid")
        {
            waterTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Metaball_liquid")
        {
            waterTouching = false;
        }
    }

}
