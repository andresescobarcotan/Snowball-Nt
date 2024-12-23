using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PartnerScript : MonoBehaviour
{   
    private void OnCollisionEnter(Collision collision) {
 
        Destroy(gameObject);
        Destroy(collision.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverMalo");
    }
}
