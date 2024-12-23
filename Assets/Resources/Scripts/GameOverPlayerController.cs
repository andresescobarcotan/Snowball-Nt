using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(OVRInput.GetDown(OVRInput.RawButton.A)){
            SceneManager.LoadScene("PrimeraEscena");
         }

         if(OVRInput.GetDown(OVRInput.RawButton.B)){
            Application.Quit();
         }
    }
}
