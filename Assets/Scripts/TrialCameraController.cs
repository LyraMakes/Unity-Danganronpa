using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TrialCameraController : MonoBehaviour
{
    [SerializeField] private float focusAngle;

    [SerializeField] private float rotationSpeed = 0.5f;
    
    [SerializeField] private Camera mainCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera ??= Camera.main;
    }

    public void SetFocusAngle(float angle) => focusAngle = angle;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = mainCamera.transform.rotation;

        // Handle Rotation
        if (Math.Abs(mainCamera.transform.rotation.y - focusAngle) > float.Epsilon)
        {
            
            Quaternion newRot = rotation;
            Vector3 eulerAngles = newRot.eulerAngles;
            eulerAngles.y = focusAngle;
            newRot.eulerAngles =  eulerAngles;
            
            rotation = Quaternion.Slerp(rotation, newRot, Time.deltaTime * rotationSpeed);
            mainCamera.transform.rotation = rotation;
        }
        
    }
}
