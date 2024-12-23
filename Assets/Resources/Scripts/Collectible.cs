using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ParticleSystem collectEffect; // Efecto de partículas.

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player".
        {
             // Activar el arma en el jugador.
            OVRPlayerCustomController playerController = other.GetComponent<OVRPlayerCustomController>();
            if (playerController != null)
            {
                playerController.ActivateWeapon();
            }

            // Reproducir efecto de partículas.
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }
            // Desactivar o destruir el objeto al entrar en contacto con el jugador.
            Destroy(gameObject);
        }
    }
}
