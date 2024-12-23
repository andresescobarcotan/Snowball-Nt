using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Obtén la referencia a la cámara principal
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Asegura que el texto mire siempre hacia la cámara
        transform.LookAt(transform.position + cameraTransform.forward);
    }
}
