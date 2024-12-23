using UnityEngine;

public class PartnerPath : MonoBehaviour
{
    public Transform[] waypoints; // Array de Waypoints
    public float speed = 2f;      // Velocidad del enemigo
    private int currentWaypointIndex = 0; // Índice del waypoint actual

    public System.Action OnDeath;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Obtener el waypoint objetivo
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Mover al enemigo hacia el waypoint
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.LookAt(targetWaypoint);
        // Verificar si alcanzó el waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Pasar al siguiente waypoint
            currentWaypointIndex++;

            // Reiniciar al primer waypoint si se completó el recorrido
            if (currentWaypointIndex >= waypoints.Length)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
