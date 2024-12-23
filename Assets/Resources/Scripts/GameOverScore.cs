using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;

    private static string[] VeryBad = new string[]
    {
        "¿Jugaste con los ojos cerrados o es tu estilo único?",
        "Esa puntuación está pidiendo una disculpa.",
        "Al menos no rompiste el récord... de peor puntuación.",
        "Pareces un NPC: malo, pero entretenido de ver.",
        "Ese marcador debería venir con un botón de reinicio."
    };

    private static string[] Normal = new string[]
    {
        "Eh, al menos no quedaste último... esta vez.",
        "Es una puntuación decente... para alguien que empezó ayer.",
        "Ni bien, ni mal: simplemente olvidable.",
        "Felicidades, estás en la zona más aburrida del ranking.",
        "¡Eres la definición de promedio! Qué logro más emocionante."
    };

    private static string[] Good = new string[]
    {
        "¡Mira quién decidió usar más del 10% de sus habilidades!",
        "No está mal, pero tampoco llames a tus amigos para presumir.",
        "Finalmente hiciste algo que no da vergüenza.",
        "A un paso de ser increíble, pero a mil de ser memorable.",
        "Felicidades, ahora solo necesitas suerte para mejorar."
    };

    private static string[] Incredible = new string[]
    {
        "¡Uf! Ahora sí se siente que sabes lo que haces.",
        "Esa puntuación es tan buena que los demás están llorando.",
        "Al menos algo en tu vida destaca, ¿no?",
        "Cuando te ven jugar, hasta los enemigos se rinden.",
        "Increíble, pero no te emociones, sigue siendo un juego."
    };

    void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        String roast = GetRoastFromScore();
        scoreText.text = "¡Has conseguido capturar a los siguientes elfos: "+SceneData.playerScore +"\n"+roast+"\n¿Quieres jugar otra partida?  ";
    }

    private String GetRoastFromScore(){
        System.Random random = new System.Random();

        if (SceneData.playerScore <= 100)
        {
            return VeryBad[random.Next(VeryBad.Length)];
        }
        else if (SceneData.playerScore <= 300)
        {
            return Normal[random.Next(Normal.Length)];
        }
        else if (SceneData.playerScore <= 800)
        {
            return Good[random.Next(Good.Length)];
        }
        else
        {
            return Incredible[random.Next(Incredible.Length)];
        }
    }
}

