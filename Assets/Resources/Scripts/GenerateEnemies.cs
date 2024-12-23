using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject theEnemy;
    [SerializeField] private int enemyCount;
    [SerializeField] private int initialEnemyCount;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float reSpawnTime=0.2f;
    [SerializeField] private GameObject player; 
    [SerializeField] private Transform point;

    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 3f;

    public float spawnRadius = 10f;   // Radio dentro del cual se puede generar el enemigo
    public float safeDistanceFromEdge = 2f; // Distancia mínima a los bordes del NavMesh

    public Vector2 scaleRange = new Vector2(0.5f, 2f); // Rango de escalas
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop(float delay = 0.0f){
        if(delay != 0)
            yield return new WaitForSeconds(delay);
        while(enemyCount < initialEnemyCount)
        {
            Debug.Log("Llamada a EnemyDrop con enemyCount: " + enemyCount);
            Vector3 spawnPosition = RandomNavmeshLocation(spawnRadius);
            // Instanciamos el enemigo en la posición calculada
            GameObject newEnemy = Instantiate(theEnemy, spawnPosition, Quaternion.identity);
            NavMeshAgent agent = newEnemy.GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.Log($"El enemigo {newEnemy.name} no tiene NavMeshAgent configurado.");
            }
            else
            {
                Debug.Log($"Enemigo {newEnemy.name} creado con NavMeshAgent independiente.");
            }
            SetGameAttributes(newEnemy);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    private void SetGameAttributes(GameObject newEnemy)
    {
        float randomScale = UnityEngine.Random.Range(scaleRange.x, scaleRange.y);
        newEnemy.transform.localScale = Vector3.one * randomScale;
        ElfEnemyController elfEnemyController = newEnemy.GetComponent<ElfEnemyController>();
        elfEnemyController.OnDeath += () => OnEnemyDeath(newEnemy);
        elfEnemyController.scoreValue = GetScoreFromScale(randomScale);
        RunAway runAway = newEnemy.GetComponent<RunAway>();
        runAway.chaser = player.transform;
        // Cambiar el color del enemigo generado
        AssignRandomColor(newEnemy);
        // Asigna una velocidad aleatoria al enemigo.
        float randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        elfEnemyController.SetSpeed(randomSpeed);

    }

    int GetScoreFromScale(float randomScale){
        float distanceLow = Math.Abs(randomScale - scaleRange.x);
        int range = (int) Math.Round(distanceLow);
        Debug.Log("Scale "+ randomScale+ " distanceLow:: "+distanceLow+ " range :: "+range);
        return range switch
        {
            0 => 10,
            1 => 10,
            2 => 9,
            3 => 8,
            4 => 5,
            5 => 5,
            6 => 4,
            7 => 3,
            8 => 2,
            9 => 1,
            10 => 1,
            _ => 1
        };
    }

    void AssignRandomColor(GameObject enemy)
    {
        
    Renderer renderer = enemy.GetComponentInChildren<Renderer>(); // O busca el Renderer en un hijo si no está en la raíz
    if (renderer != null)
    {
        // Clona el material para que esta instancia tenga un material único
        Material newMaterial = new Material(renderer.material);
        newMaterial.color = GetRandomColor(); // Asigna un color aleatorio
        renderer.material = newMaterial;
    }
    else
    {
        Debug.LogWarning($"El enemigo {enemy.name} no tiene un Renderer para cambiar el material.");
    }
}

    Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value); // Color RGB aleatorio
    }

    // Función para encontrar una posición válida dentro del NavMesh
    Vector3 RandomNavmeshLocation(float radius)
    {
          int maxAttempts = 30; // Limitar el número de intentos para encontrar un punto válido
        for (int i = 0; i < maxAttempts; i++)
        {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += transform.position; // Se agrega la posición de origen como punto de referencia

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {   
            if(hit.distance >= safeDistanceFromEdge){
            Debug.DrawRay(hit.position, Vector3.up, Color.red, 1.0f); //so you can see with gizmos
            return hit.position;
            }
        }
        }

        return Vector3.zero; // Si no se encuentra una posición válida, retorna Vector3.zero
    }
    void OnEnemyDeath(GameObject deadEnemy){
        Destroy(deadEnemy);
        enemyCount-=1;
        if(initialEnemyCount <= maxEnemyCount){
            initialEnemyCount++;
        }
        Debug.Log("Enemigo ha muerto, nuevo EnemyCount "+enemyCount);
        StartCoroutine(EnemyDrop(reSpawnTime));
    }
}