using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SpawnerPlacer : MonoBehaviour
{
    ARRaycastManager raycastManager;
    
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    public GameObject spawnerPrefab;
    
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        var touchPos = 
            Touchscreen.current.position.ReadValue();
        
        if (Touchscreen.current.IsPressed() && 
            raycastManager.Raycast(touchPos, hits))
        {
            Instantiate(spawnerPrefab, 
                hits[0].pose.position, 
                hits[0].pose.rotation);
        }
    }
}