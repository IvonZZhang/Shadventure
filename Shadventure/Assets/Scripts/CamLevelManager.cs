using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamLevelManager : MonoBehaviour
{
    //private int hitpoint  = 3;
    public Transform LevelPoints;
    public Transform LevelFlags;

    public Transform CameraTransform;
    public Transform ShadowTransform;
    public Transform PlayerTransform;
    public Transform SpawnPoints;

    int mov_flag = 0;
    int currentLevel = 0;
    int step_counter = 0;
    int total_step = 50;
    float deltaX, deltaY;

    private void Start()
    {
        deltaX = total_step / 35;
        deltaY = total_step / 15;
    }
    
    private void Update()
    {
        if(mov_flag != 0)
        {
            CameraTransform.position = CameraTransform.position 
                    // + new Vector3 (mov_flag * (deltaX/70), mov_flag * (deltaY/30), 0);
                    + new Vector3 (deltaX, deltaY, 0);
            ShadowTransform.position = ShadowTransform.position 
                    + new Vector3 (deltaX, deltaY, 0);
            if(++step_counter == total_step)
            {
                mov_flag = 0;
                step_counter = 0;
                CameraTransform.position = LevelPoints.GetChild(currentLevel - 1).position;
                ShadowTransform.position = LevelPoints.GetChild(currentLevel - 1).position + new Vector3(20.0f, -11.25f, 10.0f);
            }
            // Debug.Log("Step counter is " + step_counter + ". deltaX is " + deltaX);
            // Debug.Log("Camera is at " + CameraTransform.position);
        }
    }
    

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void MoveToLevel(int targetLevel)
    {
        Debug.Log(targetLevel + " level calls levelpoint: " + LevelPoints.GetChild(targetLevel - 1).name);
         // CameraTransform.position = LevelPoints.GetChild(targetLevel).position;
        // ShadowTransform.position = LevelPoints.GetChild(targetLevel).position + new Vector3(20.0f, -11.25f, 10.0f);
        
        // if(LevelPoints.GetChild(targetLevel).position.x - CameraTransform.position.x > 0)
        // {
        //     deltaX = 35.0f / total_step;
            
        // } else if(LevelPoints.GetChild(targetLevel).position.x - CameraTransform.position.x == 0) {
        //     deltaX = 0;
        // } else {
        //     deltaX = -35.0f / total_step;
        // }

        deltaX = (LevelPoints.GetChild(targetLevel - 1).position.x - CameraTransform.position.x) / total_step;

        // if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y > 0)
        // {
        //     deltaY = 15.0f / total_step;
            
        // } else if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y == 0) {
        //     deltaY = 0;
        // } else {
        //     deltaY = -15.0f / total_step;
        // }
        deltaY = (LevelPoints.GetChild(targetLevel - 1).position.y - CameraTransform.position.y) / total_step;
        // deltaY = LevelPoints.GetChild(targetLevel).positiom.y - CameraTransform.position.y > 0 ? deltaY : -deltaY;
        /* Don't look back */

        Debug.Log("Current level:" + currentLevel);
        try{
            GameObject.Find("Bound " + currentLevel).GetComponent<BoxCollider2D>().isTrigger = false;
        } catch(NullReferenceException e) {

        }

        mov_flag = 1;
        Debug.Log("target level: " + targetLevel);
        currentLevel = targetLevel;
    }

    public void OutScopeRespawn()
    {
        Debug.Log("Respawn! with level: " + currentLevel);
        switch(currentLevel)
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
                SetPlayerToSpawnPoint(2);
                // GameObject.Find("LevelFlag 4").SetActive(true);
                GameObject.Find("LevelFlag 4").GetComponent<Collider2D>().enabled = true;
                GameObject.Find("DieZone 5").SetActive(false);
                CameraTransform.position = new Vector3(140.0f, 15.0f, -10.0f);
                ShadowTransform.position = CameraTransform.position + new Vector3(20.0f, -11.25f, 10.0f);
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

    private void SetPlayerToSpawnPoint(int spawnPointNr)
    {
        GameObject.Find("Player").transform.position = SpawnPoints.GetChild(spawnPointNr-1).position;
    }
}

// deltaX * step = 35
// deltaY * step = 15