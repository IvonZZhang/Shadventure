using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLevelManager : MonoBehaviour
{
    //private int hitpoint  = 3;
    public Transform LevelPoints;
    public Transform LevelFlags;

    public Transform CameraTransform;
    public Transform ShadowTransform;
    public Transform PlayerTransform;

    int mov_flag = 0;
    int currentLevel = 0;
    int step_counter = 0;
    int total_step = 70;
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
                CameraTransform.position = LevelPoints.GetChild(currentLevel).position;
                ShadowTransform.position = LevelPoints.GetChild(currentLevel).position + new Vector3(20.0f, -11.25f, 10.0f);
            }
            //Debug.Log("Step counter is " + step_counter + ". deltaX is " + deltaX);
            //Debug.Log("Camera is at " + CameraTransform.position);
        }
    }
    

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void MoveToLevel(int targetLevel)
    {
        Debug.Log(targetLevel + " level calls levelpoint: " + LevelPoints.GetChild(targetLevel).name);
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

        deltaX = (LevelPoints.GetChild(targetLevel).position.x - CameraTransform.position.x) / total_step;

        // if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y > 0)
        // {
        //     deltaY = 15.0f / total_step;
            
        // } else if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y == 0) {
        //     deltaY = 0;
        // } else {
        //     deltaY = -15.0f / total_step;
        // }
        deltaY = (LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y) / total_step;
        // deltaY = LevelPoints.GetChild(targetLevel).positiom.y - CameraTransform.position.y > 0 ? deltaY : -deltaY;

        mov_flag = 1;
        Debug.Log("Current level " + currentLevel + " Target level: "+ targetLevel);
        currentLevel = targetLevel;
    }
}

// deltaX * step = 35
// deltaY * step = 15