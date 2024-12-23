using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class GeneratePartner : MonoBehaviour
{
    [SerializeField] private GameObject thePartner;
    [SerializeField] private int partnerCount;
    [SerializeField] private int maxPartnerCount;
    [SerializeField] private float reSpawnTime=1.0f;

    public Transform spawnpoint;
    public Transform[] waypoints; // Lista de waypoints

    void Start()
    {
        StartCoroutine(PartnerDrop());
    }

    IEnumerator PartnerDrop(float delay = 0.0f){
        if(delay != 0)
            yield return new WaitForSeconds(delay);
        while(partnerCount < maxPartnerCount)
        {
            Debug.Log("Llamada a PartnerDrop con enemyCount: " + partnerCount);
            // Seleccionar un waypoint aleatorio
            int randomIndex = UnityEngine.Random.Range(0, waypoints.Length);

            // Instanciamos el enemigo en la posición calculada
            GameObject newPartner = Instantiate(thePartner, spawnpoint.position, Quaternion.identity);
            SetGameAttributes(newPartner);
            yield return new WaitForSeconds(0.1f);
            partnerCount += 1;
        }
    }

    private void SetGameAttributes(GameObject newPartner)
    {
        PartnerPath partnerScript = newPartner.GetComponent<PartnerPath>();
        partnerScript.OnDeath += () => OnEnemyDeath(newPartner);
        partnerScript.waypoints = waypoints;
    }

    void OnEnemyDeath(GameObject deadEnemy){
        Destroy(deadEnemy);
        partnerCount-=1;
        Debug.Log("Compañero ha muerto, nuevo PartnerCount "+partnerCount);
        StartCoroutine(PartnerDrop(reSpawnTime));
    }
}