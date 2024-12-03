using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColorChange : MonoBehaviour
{
    [SerializeField] private Renderer sphereRenderer;
    // Update is called once per frame
    void Update()
    {
        float triggerPressure = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        sphereRenderer.material.color = Color.Lerp(Color.white, Color.red, triggerPressure);
    }
}
