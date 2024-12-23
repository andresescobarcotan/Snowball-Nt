using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BalloonScript : MonoBehaviour
{
    public float maxHeight = 2.0f;
    public float velocity = 1.0f;
    float startHeight =0;
    
    private int scoreValue=-10;

    public GameObject floatingTextPrefab; // Prefab del texto flotante
    public GameObject particles;
    public System.Action OnDeath;


    void Start()
    {
        startHeight = transform.position.y;
        maxHeight = maxHeight - startHeight;
        velocity -= Random.Range(-0.5f,0.5f);
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
    public void SetScoreValue(int _score){
        scoreValue = _score;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y -= velocity * Time.deltaTime;
        if (temp.y < startHeight || temp.y > maxHeight)
        {
            velocity *= -1;
        }
        transform.position = temp;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject clone = Instantiate(particles, transform.position, transform.rotation);
        Destroy(clone.gameObject, 2);
        OnDeath?.Invoke();
        FindObjectOfType<ScoreManager>().AddScore(scoreValue);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
