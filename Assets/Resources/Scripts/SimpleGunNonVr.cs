using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGunNonVr : MonoBehaviour
{
    public Rigidbody Ball;

    public GameObject fireParticle;

    public float velocity = 50;

    bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerRight = Input.GetKey(KeyCode.Mouse0);
        if(Input.GetKey(KeyCode.Mouse0)){
            Debug.Log("Mouse 0");
        }
        if(triggerRight  && fire == false){
             fire = true;
            GameObject fireParticleObject = Instantiate(fireParticle, transform.position, transform.rotation);
            Destroy(fireParticleObject.gameObject, 2);
             Rigidbody clone = Instantiate(Ball, transform.position, transform.rotation) as Rigidbody;
             clone.velocity = transform.TransformDirection(new Vector3(0,0, velocity));
             Destroy(clone.gameObject, 3);

        }
        if(fire==true && !triggerRight){
            fire = false;
        }

    }
}
