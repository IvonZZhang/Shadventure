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
            Debug.Log("On Trigger!!!" + this.name);
            string numbersOnly = Regex.Replace(this.name, "[^0-9]", "");
            Debug.Log(int.Parse(numbersOnly));
            Debug.Log("aaaaaaaaaaa" + levelManager.GetCurrentLevel());
            levelManager.MoveToLevel(int.Parse(numbersOnly));
        }
        
    }
}
