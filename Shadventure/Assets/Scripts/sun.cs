using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public Transform guard;
    public Transform guard_sleep;
    // Start is called before the first frame update
    void Start()
    {
        // guard_sleep.SetActive(guard_sleep);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        // Destroy(guard);
        guard.position = new Vector3(-10.0f, -30.0f, 0);
        // Visibility.Visible(guard_sleep);
        guard_sleep.position = new Vector3(-41.0f, -4.5f, 0);
    }
}
