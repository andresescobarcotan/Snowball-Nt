using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class GenerateGnericEnemy : MonoBehaviour
{
    [SerializeField] private GameObject theEnemy;
    [SerializeField] private int enemyCount;
    [SerializeField] private int initialEnemyCount;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float reSpawnTime=0.2f;
    public Transform[] waypoints; // Lista de waypoints


    public float spawnRadius = 10f;   // Radio dentro del cual se puede generar el enemigo
    public float safeDistanceFromEdge = 2f; // Distancia mínima a los bordes del NavMesh

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
            // Seleccionar un waypoint aleatorio
            int randomIndex = UnityEngine.Random.Range(0, waypoints.Length);
            Transform spawnPoint = waypoints[randomIndex];

            // Instanciamos el enemigo en la posición calculada
            GameObject newEnemy = Instantiate(theEnemy, spawnPoint.position, Quaternion.identity);
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
        BalloonScript balloonScript = newEnemy.GetComponent<BalloonScript>();
        balloonScript.OnDeath += () => OnEnemyDeath(newEnemy);
        // Cambiar el color del enemigo generado
        Color newColor = AssignRandomColor(newEnemy);
        balloonScript.SetScoreValue(setScoreByColor(newColor));
    }

    int setScoreByColor(Color newColor){
        int score = -1;
        if(newColor == Color.red){
            score = -100;
        }
        else if (newColor == Color.blue){
            score = +100;
        }
        
        return score;
    }
    Color AssignRandomColor(GameObject enemy)
    {
        
    Color result = Color.red;
    Renderer renderer = enemy.GetComponentInChildren<Renderer>(); // O busca el Renderer en un hijo si no está en la raíz
    if (renderer != null)
    {
        // Clona el material para que esta instancia tenga un material único
        Material newMaterial = new Material(renderer.material);
        result = GetRandomColor(); // Asigna un color aleatorio
        newMaterial.color = result;
        renderer.material = newMaterial;
    }
    else
    {
        Debug.LogWarning($"El enemigo {enemy.name} no tiene un Renderer para cambiar el material.");
    }
    return result;
}

    Color GetRandomColor()
    {
        int randomNumber = UnityEngine.Random.Range(1, 3); // El rango superior es exclusivo, así que usamos 5.
        return randomNumber switch
        {
            1 => Color.red,
            2 => Color.blue,
            _ => Color.red,
        };
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