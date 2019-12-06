using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DieTrigger : MonoBehaviour
{
    public Transform SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("On Trigger!!!" + this.name);
            string dieZoneNumber = Regex.Replace(this.name, "[^0-9]", "");
            Debug.Log(int.Parse(dieZoneNumber));
            switch(int.Parse(dieZoneNumber))
            {
                case 1:
                    SetPlayerToSpawnPoint(1);
                    break;
            }
        }
        
    }

    private void SetPlayerToSpawnPoint(int spawnPointNr)
    {
        GameObject.Find("Player").transform.position = SpawnPoints.GetChild(spawnPointNr-1).position;
    }
}
