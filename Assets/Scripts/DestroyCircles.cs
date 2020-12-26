using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DestroyCircles : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamera.transform.position.z > transform.position.z)
        {
            Destroy(gameObject);
        }        
    }
}
