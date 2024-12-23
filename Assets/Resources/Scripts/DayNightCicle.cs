using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Cycle Settings")]
    public float dayDuration = 60f; // Duración de un ciclo completo en segundos
    public Material skyboxMaterial;

    [Header("Skybox Colors")]
    public Color dayHorizonColor = Color.cyan;
    public Color nightHorizonColor = Color.black;
    public Color daySkyColor = Color.blue;
    public Color nightSkyColor = new Color(0.02f, 0.02f, 0.1f); // Azul oscuro para la noche

    private float timeOfDay = 0f;

    void Update()
    {
        // Avanza el tiempo en función de la duración del ciclo
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f) timeOfDay -= 1f; // Reinicia el ciclo al llegar al final

        // Interpolación entre día y noche
        float blendFactor = Mathf.Sin(timeOfDay * Mathf.PI * 2); // Oscila entre -1 y 1
        blendFactor = (blendFactor + 1f) / 2f; // Normaliza a 0 - 1

        // Actualiza los colores del Skybox
        skyboxMaterial.SetColor("_SkyTint", Color.Lerp(nightSkyColor, daySkyColor, blendFactor));
        skyboxMaterial.SetColor("_GroundColor", Color.Lerp(nightHorizonColor, dayHorizonColor, blendFactor));

        // Ajusta la iluminación ambiental
        RenderSettings.ambientLight = Color.Lerp(nightHorizonColor, dayHorizonColor, blendFactor);
    }
}
