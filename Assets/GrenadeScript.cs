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
    public GameObject sirpalePrefab;
    public AudioClip possaus;
    public AudioClip pamaus;
    private AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        audiosource = gameObject.GetComponent<AudioSource>();
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
            rigid.AddForce(transform.forward * force * Time.deltaTime, ForceMode.Impulse);
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
        audiosource.PlayOneShot(possaus, 1f);
        audiosource.PlayOneShot(pamaus, 1f);
        Invoke("Sirpaleet", 0f);
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

    void Sirpaleet()
    {
        for (int i = 0; i < 16; i++)
        {
            switch (i)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 1:
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 2:
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 3:
                    transform.localRotation = Quaternion.Euler(0, 270, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 4:
                    transform.localRotation = Quaternion.Euler(0, 45, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 5:
                    transform.localRotation = Quaternion.Euler(0, 135, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 6:
                    transform.localRotation = Quaternion.Euler(0, 215, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 7:
                    transform.localRotation = Quaternion.Euler(0, 315, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 8:
                    transform.localRotation = Quaternion.Euler(0, 22, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 9:
                    transform.localRotation = Quaternion.Euler(0, 111, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 10:
                    transform.localRotation = Quaternion.Euler(0, 200, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 11:
                    transform.localRotation = Quaternion.Euler(0, 293, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 12:
                    transform.localRotation = Quaternion.Euler(0, 66, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 13:
                    transform.localRotation = Quaternion.Euler(0, 154, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 14:
                    transform.localRotation = Quaternion.Euler(0, 238, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 15:
                    transform.localRotation = Quaternion.Euler(0, 338, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
            }
        }
    }

    public void Tuho()
    {
        Destroy(gameObject);
    }
}
