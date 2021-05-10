using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpetsNavmesh : MonoBehaviour
{
    Animator animator;
    NavMeshAgent navMeshAgent;

    public Transform target;
    public int index;
    public float chaseRange;
    public float shootRange;
    float distanceToTarget = Mathf.Infinity;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    private float lastFire = 0.0f;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        Invoke("StateMachine", 1f);
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
            ChaseHero();
        }
        else if (distanceToTarget >= chaseRange)
        {
            idle();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = new Color(2, 2, 2, 0.75f);
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    void StateMachine()
    {
        if (distanceToTarget <= chaseRange)
        {
            Debug.Log("Statemasinassa");
            index = Random.Range(0, 3);
            switch (index)
            {
                case 0:
                    ChaseHero();
                    break;
                case 1:
                    StandAndShoot();
                    break;
                case 2:
                    ChaseHero();
                    break;
                default:
                    StandAndShoot();
                    break;
            }
        }
        
    }

    public void ChaseHero()
    {
        animator.SetFloat("Speed", 1f);
        Debug.Log("ChaseHero");
        GetComponent<NavMeshAgent>().speed = 20f;
        navMeshAgent.SetDestination(target.position);
        if (distanceToTarget <= shootRange)
        {
            StandAndShoot();
        }

    }

    public void StandAndShoot()
    {
        animator.SetFloat("Speed", 0.1f);
        Debug.Log("StandAndShoot");
        navMeshAgent.SetDestination(target.position);
        GetComponent<NavMeshAgent>().speed = 0.1f;
        if (Time.time > lastFire)
        {
            lastFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        }
    }

    public void idle()
    {
        //Debug.Log("idlessä");
        GetComponent<NavMeshAgent>().speed = 0.01f;
        animator.SetFloat("Speed", 0.33f);
    }
}

