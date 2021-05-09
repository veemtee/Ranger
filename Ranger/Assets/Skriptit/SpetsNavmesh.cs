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
    public float standRange;

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
        Gizmos.color = new Color(3, 3, 3, 0.75f);
        Gizmos.DrawWireSphere(transform.position, standRange);
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
        animator.SetTrigger("Sprint");
        Debug.Log("ChaseHero");
        GetComponent<NavMeshAgent>().speed = 100f;
        navMeshAgent.SetDestination(target.position);
        if (distanceToTarget < shootRange)
        {
            RunAndShoot();
        }

    }

    public void StandAndShoot()
    {
        if (distanceToTarget > standRange)
        {
            RunAndShoot();
        }
        else
        {
            animator.ResetTrigger("Sprint");
            animator.ResetTrigger("RunShoot");
            animator.SetTrigger("StandShoot");
            Debug.Log("StandAndShoot");
            navMeshAgent.SetDestination(target.position);
            GetComponent<NavMeshAgent>().speed = 0.1f;
            if (Time.time > lastFire)
            {
                lastFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            }

        }
    }

    public void RunAndShoot()
    {
        if (distanceToTarget < standRange)
        {
            StandAndShoot();
        }

        else if (distanceToTarget > shootRange)
        {
            ChaseHero();
        }

        else
        {
            animator.ResetTrigger("Sprint");
            animator.SetTrigger("RunShoot");
            Debug.Log("RunAndShoot");
            navMeshAgent.SetDestination(target.position);
            GetComponent<NavMeshAgent>().speed = 50f;
            if (Time.time > lastFire)
            {
                lastFire = Time.time + fireRate;
                Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            }

            if (distanceToTarget < standRange)
            {
                StandAndShoot();
            }

            else if (distanceToTarget > shootRange)
            {
                ChaseHero();
            }

        }
    }

    public void idle()
    {
        Debug.Log("idlessä");
        GetComponent<NavMeshAgent>().speed = 0.01f;
        animator.SetTrigger("Idle");
    }
}

