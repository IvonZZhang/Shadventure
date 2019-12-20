using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DieTrigger : MonoBehaviour
{
    public Transform SpawnPoints;
    public Transform CameraTransform;
    public Transform ShadowTransform;
    public CamLevelManager levelManager;

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
            Debug.Log("Die Zone nr: " + int.Parse(dieZoneNumber));
            GetComponent<AudioSource>().Play();
            switch(int.Parse(dieZoneNumber))
            {
                case 1:
                    SetPlayerToSpawnPoint(1);
                    break;
                case 2:
                    SetPlayerToSpawnPoint(4);
                    GameObject.Find("LevelFlag 9").GetComponent<Collider2D>().enabled = true;
                    GameObject.Find("LevelFlag 10").GetComponent<Collider2D>().enabled = true;
                    // GameObject.Find("Bound 9").GetComponent<Collider2D>().isTrigger = true;
                    levelManager.SetCurrentLevel(9);
                    CameraTransform.position = new Vector3(196.0f, 30.0f, -10.0f);
                    ShadowTransform.position = CameraTransform.position + new Vector3(20.0f, -11.25f, 10.0f);
                    break;
                case 3:
                    SetPlayerToSpawnPoint(3);
                    break;
                case 4:
                    SetPlayerToSpawnPoint(3);
                    break;
                case 5:
                    Debug.Log("case 5 entered.");
                    SetPlayerToSpawnPoint(2);
                    GameObject.Find("LevelFlag 4").SetActive(true);
                    GameObject.Find("DieZone 5").SetActive(false);
                    CameraTransform.position = new Vector3(140.0f, 15.0f, -10.0f);
                    ShadowTransform.position = CameraTransform.position + new Vector3(20.0f, -11.25f, 10.0f);
                    break;
                case 6:
                    SetPlayerToSpawnPoint(2);
                    GameObject.Find("LevelFlag 4").SetActive(true);
                    GameObject.Find("LevelFlag 5").SetActive(true);
                    GameObject.Find("LevelFlag 6").SetActive(true);
                    GameObject.Find("DieZone 5").SetActive(false);
                    GameObject.Find("DieZone 6").SetActive(false);
                    GameObject.Find("Bound 5").GetComponent<BoxCollider2D>().isTrigger = true;
                    CameraTransform.position = new Vector3(140.0f, 15.0f, -10.0f);
                    ShadowTransform.position = CameraTransform.position + new Vector3(20.0f, -11.25f, 10.0f);
                    break;
                default:
                    break;
            }
        }
        
    }

    private void SetPlayerToSpawnPoint(int spawnPointNr)
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.Find("Player").transform.position = SpawnPoints.GetChild(spawnPointNr-1).position;
    }
}