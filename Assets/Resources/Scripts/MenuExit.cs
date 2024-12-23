using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExit : MonoBehaviour
{
    public MenuController menuController;

    private void OnCollisionEnter(Collision collision) {
        menuController.QuitGame();
    }
}
