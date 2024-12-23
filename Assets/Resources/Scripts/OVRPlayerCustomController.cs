using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class OVRPlayerCustomController : MonoBehaviour
{
    [SerializeField] private GameObject leftBigGun;
    [SerializeField] private OVRPlayerController oVRPlayerController;

    [SerializeField] private float runVelocity=0.1f;

    public void ActivateWeapon(){
        leftBigGun.SetActive(true);
    }
    private float oldVelocity;
    private void Start(){
        leftBigGun.SetActive(false);
        oldVelocity = oVRPlayerController.Acceleration;
    }
    private void Update() {

        if(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)){
            oVRPlayerController.Acceleration = runVelocity;
        }
        if(OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)){
            oVRPlayerController.Acceleration = oldVelocity;
        } 

    }



}
