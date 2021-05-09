using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VihuSkript : MonoBehaviour
{
    NavMeshAgent spetsNavmesh;
    public Transform objectoChase;
    Animator animator;
    public int index;
    public float timeBetweenShots;
    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public GameObject kranu;
    //private float lastFire = 0.0f;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startissa");
        spetsNavmesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        Invoke("StateMachine", 0.25f);
        Debug.Log("startEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StateMachine()
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
                Flank();
                break;
            default:
                grenade();
                break;
        }
    }

    void ChaseHero()
    {
        //animator.SetTrigger("Running");
        animator.SetFloat("Speed", 1f);
        Debug.Log("ChaseHero");
        startTimeBtwShots = 1f;
        timeBetweenShots = 2f;
        GetComponent<NavMeshAgent>().speed = 35f;
        spetsNavmesh.SetDestination(objectoChase.position);
        Invoke("StateMachine", 2f);
    }

    void StandAndShoot()
    {
        timeBetweenShots = 0.1f;
        startTimeBtwShots = 0.1f;
        animator.SetFloat("Speed", 3f);
        Debug.Log("StandAndShoot");
        spetsNavmesh.SetDestination(-objectoChase.position);
        GetComponent<NavMeshAgent>().speed = 0.01f;
        //startTimeBtwShots = 0.45f;
        //timeBetweenShots = 0.45f;

        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            //suuliekki.Play();
            timeBetweenShots = startTimeBtwShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
        Invoke("StateMachine", 3f);
    }

    void Flank()
    {
        animator.SetFloat("Speed", 2f);
        Debug.Log("Flank");
        startTimeBtwShots = 10f;
        timeBetweenShots = 10f;
        GetComponent<NavMeshAgent>().speed = 50f;
        float eks = Random.Range(-100, 100);
        float y = 0.5f;
        float zet = Random.Range(-100, 100);
        Vector3 sekopaikka = new Vector3(eks, y, zet);
        //transform.position = sekopaikka;
        spetsNavmesh.SetDestination(sekopaikka);
        Invoke("StateMachine", 2f);
    }

    void grenade()
    {
        animator.SetFloat("Speed", 4f);
        GetComponent<NavMeshAgent>().speed = 10f;
        spetsNavmesh.SetDestination(-objectoChase.position);
        Instantiate(kranu, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        Invoke("StateMachine", 2f);
    }

    public Vector3 RandomPaikka(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit osuma;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out osuma, radius, 1))
        {
            finalPosition = osuma.position;
        }
        return finalPosition;
    }
}
