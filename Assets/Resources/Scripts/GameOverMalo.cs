using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMalo : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    private const String prefix = "¡HAS DISPARADO A UN COMPAÑERO!\n";
    private const String postfix = "\n¿Quieres jugar otra partida?";

    private String[] gameoverPhrases = {"Con enemigos como tú, ¿quién necesita aliados?", "¿Te pagan los contrarios o solo es talento natural?", "Esa puntería es tan mala que debería considerarse un arma en sí misma.", "Tranquilo, que la próxima bala también le da al equipo equivocado.","¿Practicaste en una feria? Porque apuntas como si quisieras ganar un peluche.","Menos mal que no estás en un apocalipsis zombi, o seríamos los primeros en morir.","¿Estás jugando en difícil o solo es difícil verte jugar?","Tu precisión está a la altura de tus decisiones: lamentable.","Dale, sigue practicando. Algún día hasta los enemigos te tendrán miedo.","Tu puntería tiene un don especial: hacer llorar a tus compañeros."};

    void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        int i = UnityEngine.Random.Range(0, gameoverPhrases.Length);
        scoreText.text = prefix + gameoverPhrases[i] + postfix;
    }
}

