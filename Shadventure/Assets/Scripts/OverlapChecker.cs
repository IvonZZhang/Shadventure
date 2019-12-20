using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapChecker : MonoBehaviour
{
    private int nrOfColliders = 0;
    private Collider2D[] results;
    public Transform SpawnPoints;
    public CamLevelManager levelManager;
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
        contactFilter.SetLayerMask(LayerMask.GetMask("Player"));
        nrOfColliders = GetComponent<Collider2D>().OverlapCollider(contactFilter, results);    
        // Debug.Log("Number of colliders: " + nrOfColliders);
        // Debug.Log(results[0] + " | " + results[1] + " | " + results[2] + " | " + results[3] + " | " + results[4]);
        if(nrOfColliders > 2)
        {
            Debug.Log("It went into wall!");
            GetComponent<AudioSource>().Play();
            switch (levelManager.GetCurrentLevel())
            {
                case 0:
                    SetPlayerToSpawnPoint(1);
                    break;
                case 1:
                    SetPlayerToSpawnPoint(6);
                    break;
                case 2:
                    SetPlayerToSpawnPoint(5);
                    break;
                case 3:
                    SetPlayerToSpawnPoint(7);
                    break;
                case 4:
                    SetPlayerToSpawnPoint(2);
                    break;
                case 5:
                    SetPlayerToSpawnPoint(8);
                    break;
                case 6:
                    SetPlayerToSpawnPoint(9);
                    break;
                case 7:
                    SetPlayerToSpawnPoint(10);
                    break;
                case 8:
                    SetPlayerToSpawnPoint(11);
                    break;
                case 9:
                    SetPlayerToSpawnPoint(12);
                    break;
                case 10:
                    SetPlayerToSpawnPoint(13);
                    break;
                case 11:
                    SetPlayerToSpawnPoint(14);
                    break;
                case 12:
                    SetPlayerToSpawnPoint(15);
                    break;
                case 13:
                    SetPlayerToSpawnPoint(3);
                    break;
                case 14:
                    SetPlayerToSpawnPoint(16);
                    break;
                default:
                    break;
            }
        }
    }

    private void SetPlayerToSpawnPoint(int spawnPointNr)
    {
        GameObject.Find("Player").transform.position = SpawnPoints.GetChild(spawnPointNr-1).position;
    }
}
