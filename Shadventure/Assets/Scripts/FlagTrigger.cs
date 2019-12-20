using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class FlagTrigger : MonoBehaviour
{
    public CamLevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        // levelManager = GameObject.Find("ScriptRunner").GetComponent(typeof(CamLevelManager));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            if(this.name == "RestartFlag 14")
            {
                FindObjectOfType<GameManager>().Restart();
            }
            
            // Debug.Log("On Trigger!!!" + this.name);
            string flagNumber = Regex.Replace(this.name, "[^0-9]", "");
            Debug.Log("Flag number: " + int.Parse(flagNumber));
            Debug.Log("Current level when trigger the flag: " + levelManager.GetCurrentLevel());
            switch (levelManager.GetCurrentLevel())
            {
                case 3:
                    GameObject.Find("Normal_block1").SetActive(false);
                    GameObject.Find("Normal_block2").SetActive(false);
                    GameObject.Find("PoisonBrick").SetActive(false);
                    break;
                case 4:
                    // GameObject.Find("DieZone 5").SetActive(true);
                    break;
                default:
                    break;
            }
            levelManager.MoveToLevel(int.Parse(flagNumber) + 1);

            // this.gameObject.SetActive(false);
            Debug.Log("collider is enabled? " + this.gameObject.GetComponent<Collider2D>().enabled);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log("collider on level disabled");
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}