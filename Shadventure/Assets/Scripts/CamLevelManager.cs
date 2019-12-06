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
    // Script flagTrigger;
    // int incX, incY;

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
                    + new Vector3 (deltaX/70, deltaY/30, 0);
            ShadowTransform.position = ShadowTransform.position 
                    + new Vector3 (deltaX/70, deltaY/30, 0);
            if(++step_counter == total_step)
            {
                mov_flag = 0;
            }
        }
    }
    

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void MoveToLevel(int targetLevel)
    {
        Debug.Log(targetLevel + " level calls levelpoint: " + LevelPoints.GetChild(targetLevel).name);
        CameraTransform.position = LevelPoints.GetChild(targetLevel).position;
        ShadowTransform.position = LevelPoints.GetChild(targetLevel).position + new Vector3(20.0f, -11.25f, 10.0f);
        
        if(LevelPoints.GetChild(targetLevel).position.x - CameraTransform.position.x > 0)
        {
            deltaX = total_step / 35;
            
        } else if(LevelPoints.GetChild(targetLevel).position.x - CameraTransform.position.x == 0) {
            deltaX = 0;
        } else {
            deltaX = - total_step / 35;
        }

        if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y > 0)
        {
            deltaY = total_step / 35;
            
        } else if(LevelPoints.GetChild(targetLevel).position.y - CameraTransform.position.y == 0) {
            deltaY = 0;
        } else {
            deltaY = - total_step / 35;
        }
        // deltaY = LevelPoints.GetChild(targetLevel).positiom.y - CameraTransform.position.y > 0 ? deltaY : -deltaY;

        mov_flag = 1;
        currentLevel = targetLevel;
    }
}
