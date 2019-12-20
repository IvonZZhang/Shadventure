using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOverlapChecker : MonoBehaviour
{
    private int nrOfColliders = 0;
    private Collider2D[] results;
    // Start is called before the first frame update
    void Start()
    {
        results = new Collider2D[5];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        // contactFilter.isFiltering = true;
        contactFilter.useLayerMask = true;
        // contactFilter.layerMask = LayerMask.GetMask("Player");
        contactFilter.SetLayerMask(LayerMask.GetMask("Object"));
        nrOfColliders = GetComponent<Collider2D>().OverlapCollider(contactFilter, results);    
        // Debug.Log("Number of colliders: " + nrOfColliders);
        // Debug.Log(results[0] + " | " + results[1] + " | " + results[2] + " | " + results[3] + " | " + results[4]);
        if(nrOfColliders > 0)
        {
            Debug.Log("It went into wall!");
            // GetComponent<AudioSource>().Play();
            // SetPlayerToSpawnPoint(2);
            GameObject.Find("Normal_block1").transform.position = new Vector3(67.3f, 26.8f, 0);
            GameObject.Find("Normal_block2").transform.position = new Vector3(76.2f, 26.8f, 0);
            GameObject.Find("PoisonBrick").transform.position = new Vector3(75.7f, 19.4f, 0);
        }
    }

}
