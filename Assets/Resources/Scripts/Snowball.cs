using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
     public GameObject particles;

    private void OnCollisionEnter(Collision collision) {
        GameObject clone = Instantiate(particles, transform.position, transform.rotation);
        Destroy(clone.gameObject, 2);
    }
}
