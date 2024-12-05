using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class Jump : MonoBehaviour
{
    [SerializeField] private Canvas minimapCanvas;

    private void Update() {
        if(OVRInput.Get(OVRInput.RawButton.Y)){
            minimapCanvas.enabled = !minimapCanvas.enabled;
        }

    }



}
