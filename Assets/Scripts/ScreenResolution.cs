using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    float aspect;
    void Start()
    {
        aspect = Camera.main.aspect;
        
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Screen.width / Screen.height;
        
        
        Camera.main.aspect = 0.6f;
        float aspect2 = Camera.main.aspect;
        
        if (aspect2 != aspect)
        {
            aspect = aspect2;
          
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
