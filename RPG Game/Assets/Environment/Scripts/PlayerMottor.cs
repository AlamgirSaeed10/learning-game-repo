using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMottor : MonoBehaviour
{
    Transform target;
    NavMeshAgent meshAgent;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        if (target != null) {
            meshAgent.SetDestination(target.position);
            FaceTarget();
        }
        
    }

    public void moveToPoint(Vector3 point) {
        meshAgent.SetDestination(point);
    }

    public void FollowTarget(Intractable newTarget) {
        meshAgent.stoppingDistance = newTarget.radius * 0.8f;
        meshAgent.updateRotation = false; 
            target = newTarget.transform;



    }

    public void StopfollowingTarget() {
        meshAgent.stoppingDistance = 0f;
        meshAgent.updateRotation = true;
        target = null;
    }
    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}
