using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountdownTimer : MonoBehaviour
{
    public float startTime = 120f; // Tiempo inicial en segundos.
    
    public TextMeshProUGUI timerText; // Texto para mostrar el tiempo.
    private float currentTime; // Tiempo restante.
    
    void Start()
    {
        currentTime = startTime; // Inicializa el tiempo.
        UpdateTimerUI(); // Actualiza el texto al inicio.
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Reduce el tiempo.
            currentTime = Mathf.Max(currentTime, 0); // Evita valores negativos.
            UpdateTimerUI();
        }
        else
        {
            EndGame(); // Llama a la función cuando el tiempo llega a 0.
        }
    }

    // Actualiza el texto del temporizador en la UI.
    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); // Minutos restantes.
        int seconds = Mathf.FloorToInt(currentTime % 60); // Segundos restantes.
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Formato "MM:SS".
    }

    // Acciones a realizar cuando el tiempo termina.
    void EndGame()
    {
        Debug.Log("¡Fin del juego!");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
