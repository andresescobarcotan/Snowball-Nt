using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    public MenuController menuController;

    private void OnCollisionEnter(Collision collision) {
        menuController.StartGame();
    }
}
