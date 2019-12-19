using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public Transform guard;
    public Transform guard_sleep;
    public Transform moon;
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
        Debug.Log("OnBecameVisible called.");
        // Destroy(guard);
        guard.position = guard.position + new Vector3(0, -15.0f, 0);
        // Visibility.Visible(guard_sleep);
        guard_sleep.position = guard_sleep.position + new Vector3(0, 15.0f, 0);
        moon.position += new Vector3(0, -20.0f, 0);
    }
}
