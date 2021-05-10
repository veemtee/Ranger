using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float timer = 2;
    float countdown;
    bool hasExploded;
    public GameObject explosionEffect;
    public GameObject sirpale;
    public float expRadius;
    public float expForce = 500f;
    //public Collider explosionRadius;

    public float force;
    GameObject spawn;
    public Rigidbody rigid;
    public bool heitto = false;


    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        //spawn = GameObject.FindGameObjectWithTag("HeroGranu");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            //explosionRadius.gameObject.SetActive(true);
            explosion();
            hasExploded = true;
        }

        if (heitto == true)
        {
            rigid.AddForce(transform.up * force * Time.deltaTime, ForceMode.Impulse);
            heitto = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        Gizmos.DrawWireSphere(transform.position, expRadius);
        Gizmos.color = new Color(2, 2, 2, 0.75f);
        Gizmos.DrawWireSphere(transform.position, expForce);
    }

    public void GranuSpawn()
    {
        Debug.Log("granuspawniin");
        //Instantiate(granu, spawn.transform.position, spawn.transform.rotation);
        Debug.Log("InstaaGranu");
        transform.parent = spawn.transform;
        rigid.useGravity = false;
    }

    public void GranuLentoon()
    {
        Debug.Log("ranulennossa");
        heitto = true;
        //transform.parent = null;
        //rigid.useGravity = true;
        //transform.rotation = spawn.transform.rotation;
        //rigid.AddForce(transform.up * force * Time.deltaTime, ForceMode.Impulse);
        
        Debug.Log("ranulennossa2");
    }

    public void explosion()
    {
        //explosionRadius.gameObject.SetActive(true);
        GameObject spawnedParticle = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(spawnedParticle, 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, expRadius);
        

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            //Animator anim = nearbyObject.GetComponent<Animator>();
            if(rb != null)
            {
                
                rb.AddExplosionForce(expForce, transform.position, expRadius);
            }
        }

        Invoke("Tuho", 0.01f);
        
    }

    public void Tuho()
    {
        Destroy(gameObject);
    }
}
