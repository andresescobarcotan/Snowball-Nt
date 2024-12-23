using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Cargar la escena principal del juego
        SceneManager.LoadScene("Instrucciones");
    }

    public void QuitGame()
    {
        // Salir del juego
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
