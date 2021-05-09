using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spetsnats : MonoBehaviour
{
    NavMeshAgent spetsNavmesh;
    public Transform objecttoChase;

    // Start is called before the first frame update
    void Start()
    {
        spetsNavmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        spetsNavmesh.speed = 20f;
        spetsNavmesh.SetDestination(objecttoChase.position);
    }
}
