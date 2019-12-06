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
    // Script flagTrigger;
    // int incX, incY;

    private void Start()
    {
        // flagTrigger = LevelFlags.GetChild(currentLevel).GetComponentInParent(typeof(FlagTrigger));

    }
    
    private void Update()
    {
        // if(PlayerTransform.position.x > 5 && PlayerTransform.position.x < PositionLvl1.position.x )
        // {
        //     CameraTransform.position.x =  CameraTransform.position.x + 0.1 ;
        // }
        // if(PlayerTransform.position.x > PositionLvl1.position.x)
        // {
        //     CameraTransform.position = PositionLvl1.position;
        // }
        // if(PlayerTransform.position.x > CameraTransform.position.x + 15){
        //     mov_flag = 1;
        // }

        if(mov_flag == 1){
            // flagTrigger.
            CameraTransform.position = LevelPoints.GetChild(0).position;
            ShadowTransform.position = LevelPoints.GetChild(0).position + new Vector3(20.0f, -11.25f, 10.0f);
            mov_flag = 2;
        }




        // if(mov_flag == 1)
        // {
            //CameraTransform.position = PositionLvl1.position;
            // if(CameraTransform.position.x < PositionLvl1.position.x)
            // {
            //     CameraTransform.position = CameraTransform.position + new Vector3 (0.5f, 0, 0);
            //     ShadowTransform.position = ShadowTransform.position + new Vector3 (0.5f, 0, 0);
            // }
            // if(CameraTransform.position.y < PositionLvl1.position.y)
            // {
            //     CameraTransform.position = CameraTransform.position + new Vector3 (0, 0.5f, 0);
            //     ShadowTransform.position = ShadowTransform.position + new Vector3 (0, 0.5f, 0);
            // }
            // else {
            
                // CameraTransform.position = PositionLvl1.position;
                // ShadowTransform.position = PositionLvl1.position + new Vector3(20.0f, -11.25f, 10.0f);
                // mov_flag = 2;
            // }
        }
    // }/

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void MoveToLevel(int targetLevel)
    {
        Debug.Log(targetLevel + " level calls levelpoint: " + LevelPoints.GetChild(targetLevel).name);
        CameraTransform.position = LevelPoints.GetChild(targetLevel).position;
        ShadowTransform.position = LevelPoints.GetChild(targetLevel).position + new Vector3(20.0f, -11.25f, 10.0f);
        currentLevel = targetLevel;
    }

}
