using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    //private int hitpoint  = 3;
    public Transform spawnPosition;

    public Transform playerTransform;

    public float dieY = -10.0f;
    
    private void Update()
    {
        if(playerTransform.position.y < dieY )
        {
            playerTransform.position = spawnPosition.position;
        }
    }
}
