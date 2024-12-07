using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class OVRPlayerCustomController : MonoBehaviour
{
    [SerializeField] private Canvas minimapCanvas;

    [SerializeField] private OVRPlayerController oVRPlayerController;

    [SerializeField] private float runVelocity;

    private float oldVelocity;
    private void Update() {
        if(OVRInput.Get(OVRInput.RawButton.Y)){
            minimapCanvas.enabled = !minimapCanvas.enabled;
        }
        if(OVRInput.Get(OVRInput.RawButton.B)){
            oVRPlayerController.Jump();
        }
        if(OVRInput.Get(OVRInput.RawButton.A)){
            oldVelocity = oVRPlayerController.Acceleration;
            oVRPlayerController.Acceleration = runVelocity;

        } else {
            oVRPlayerController.Acceleration = oldVelocity;
        }

    }



}
