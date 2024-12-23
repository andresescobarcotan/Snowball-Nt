using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] public Transform chaser = null;
    [SerializeField] private float displacementDistance = 5f;

    void Start() 
    {
        if(agent==null)
            if(!TryGetComponent(out agent))
                Debug.LogWarning(name + " needs a navmesh agent");
    }

    private void Update(){
        if(chaser==null)
            return;
        UnityEngine.Vector3 normDir = (chaser.position - transform.position).normalized;
        normDir = UnityEngine.Quaternion.AngleAxis(UnityEngine.Random.Range(0,179), UnityEngine.Vector3.up) * normDir;
        MoveToPos(transform.position - (normDir* displacementDistance));
    }    
    
    private void MoveToPos(UnityEngine.Vector3 pos){
        agent.SetDestination(pos);
        agent.isStopped = false;
    }
}
