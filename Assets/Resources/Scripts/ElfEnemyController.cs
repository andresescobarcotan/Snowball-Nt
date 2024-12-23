using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ElfEnemyController : MonoBehaviour
{
    public GameObject particles;
    public System.Action OnDeath;
    public GameObject floatingTextPrefab; // Prefab del texto flotante

    public int scoreValue=1;

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetSpeed(float speed)
    {
        if (agent != null)
        {
            agent.speed = speed; // Ajusta la velocidad del NavMeshAgent.
            Debug.Log("Elf Speed :: "+agent.speed);
        }
    }

    private void ShowFloatingText()
    {
        if (floatingTextPrefab)
        {
            // Instanciar el texto flotante
            GameObject floatingText = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);

            // Configurar el texto para que muestre el puntaje
            floatingText.GetComponent<TextMeshPro>().text = scoreValue.ToString();
        }
    }
    
    private void OnCollisionEnter(Collision collision) {
        ShowFloatingText();
        GameObject clone = Instantiate(particles, transform.position, transform.rotation);
        Destroy(clone.gameObject, 2);
        Debug.Log("He muerto, invocando evento");
        OnDeath?.Invoke();
        FindObjectOfType<ScoreManager>().AddScore(scoreValue);
        Destroy(gameObject);
        Destroy(collision.gameObject);

    }
}
