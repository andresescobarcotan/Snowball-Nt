using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    public float lifetime = 2f; // Tiempo de vida del texto
    public float floatSpeed = 1f; // Velocidad hacia arriba

    void Update()
    {
        // Mueve el texto hacia arriba
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        // Destruye el texto después del tiempo de vida
        Destroy(gameObject, lifetime);
    }
}
