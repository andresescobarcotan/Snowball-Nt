using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Distancia máxima del rayo
    private float maxRayDistance = 10000f; // 10,000 unidades

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Crear el rayo
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            // Si el rayo golpea algo, dibuja el rayo hasta el punto de impacto
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Si no golpea nada, extiende el rayo hasta la distancia máxima
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * maxRayDistance);
        }
    }
}

