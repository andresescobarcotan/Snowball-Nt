using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public float rotationSpeed = 5f;  // Velocidad de rotación
    public float movementRadius = 10f; // Radio de movimiento
    private NavMeshAgent agent;
    private Vector3 spawnPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError($"El NavMeshAgent no está configurado correctamente en: {gameObject.name}");
            return;
        }
        spawnPoint = transform.position; // Punto de referencia inicial
        MoveToRandomPosition();
        RotateTowardsMovement();
    }

    void Update()
    {
        // Si el enemigo llega al destino, genera un nuevo punto
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            MoveToRandomPosition();
        }
        RotateTowardsMovement();
    }

    void MoveToRandomPosition()
    {
        Vector3 randomPosition = GetRandomPointOnNavMesh(spawnPoint, movementRadius);
        if (randomPosition != Vector3.zero)
        {
            agent.SetDestination(randomPosition);
        }

    }

    Vector3 GetRandomPointOnNavMesh(Vector3 center, float radius)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * radius;
        randomPoint.y = center.y;

        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return Vector3.zero;
    }

    void RotateTowardsMovement()
    {
        // Verificamos si el agente se está moviendo
        if (agent.velocity.sqrMagnitude > 0.1f)  // Comprobamos que la velocidad es mayor que un umbral (evitar el jitter cuando está quieto)
        {
            // La dirección hacia donde está moviéndose el agente
            Vector3 direction = agent.velocity.normalized;

            // Crear una rotación en función de la dirección del movimiento
            Quaternion toRotation = Quaternion.LookRotation(direction);

            // Rotar el enemigo suavemente hacia la nueva rotación usando Lerp
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}