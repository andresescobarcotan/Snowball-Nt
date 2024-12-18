using System.Collections;
using System.Collections.Generic;
using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private bool pressYRaw;

    [SerializeField] private OVRInput.Controller controller;

    void Update() {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
        transform.Translate(new Vector3(axis.x, 0, axis.y)* speed * Time.deltaTime);

        if(OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.down * speed * Time.deltaTime);

        pressYRaw = OVRInput.Get(OVRInput.RawButton.Y);
    }
}
