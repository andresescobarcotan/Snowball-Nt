using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SnowballLauncher : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float punchThreshold = 1.5f;
    [SerializeField] private float forceMultiplier = 2f;
    [SerializeField] private float cooldown = 0.5f;
    private float lastPunchTime;

    void Update(){
        if(Time.time < lastPunchTime + cooldown) return;

        UnityEngine.Vector3 controllerVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        UnityEngine.Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        float speed = controllerVelocity.magnitude;

        bool isThrowingFoward = UnityEngine.Vector3.Dot(controllerVelocity.normalized, controllerRotation * UnityEngine.Vector3.forward) > 0;
        // speed > punchThreshold && isThrowingFoward
        if(OVRInput.Get(OVRInput.Button.One)){
            UnityEngine.Vector3 controllerPosition; 
            controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            FireProjectile(controllerPosition, controllerRotation, controllerVelocity);
            lastPunchTime = Time.time;
        }


    }

    void FireProjectile(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation, UnityEngine.Vector3 velocity) {
        UnityEngine.Vector3 finalPosition = transform.TransformPoint(position);
        GameObject projectile = Instantiate(projectilePrefab, finalPosition, rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(rotation*UnityEngine.Vector3.forward * velocity.magnitude*forceMultiplier, ForceMode.VelocityChange);
        Destroy(projectile, 3f);
    }

}
