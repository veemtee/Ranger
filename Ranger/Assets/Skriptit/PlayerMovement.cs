using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody playerRb;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject[] sarjaSpawn;
    public GameObject GrenadeSpawn;
    public GameObject Kranu;
    private float lastFire = 0.0f;
    int shotIndex = 0;
    Vector2 inputaxis;
    //public ParticleSystem suuliekki;
    //public ParticleSystem blood;
    public float fireRate;
    //public Gamemanager gamemanager;
    Animator MyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MyAnimator.SetFloat("Speed", 0);

        inputaxis.x = Input.GetAxisRaw("Horizontal");
        inputaxis.y = Input.GetAxisRaw("Vertical");
        inputaxis.Normalize();

        if (Input.GetButton("Fire1"))
        {
            MyAnimator.SetFloat("Speed", 0.33f);
            if (Time.time > lastFire)
            {
                //MyAnimator.SetTrigger("Shooting");
                //fireRate = 0.12f;
                //float lastfire = 0.1f;
               
                speed = 20.0f;
                lastFire = Time.time + fireRate;
                Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
                //suuliekki.Play();
                shotIndex++;
                if (shotIndex > 2)
                    shotIndex = 0;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            speed = 60f;
            
        }

      /*  if (Input.GetKeyDown("Fire2"))
        {
            MyAnimator.SetFloat("Speed", 1);
            speed = (speed * 2);
        }
        if (Input.GetKeyUp("Fire2"))
        {
            speed = (speed / 2);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

       /* if (Input.GetButtonDown("FIre2"))
        {
            Instantiate(Kranu, GrenadeSpawn.transform.position, GrenadeSpawn.transform.rotation);
        }  */

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "VihuBullet")
        {
            //blood.Play();
            Debug.Log("LUOTISATTTUU");
            //gamemanager.score = -100;
        }
        else if (other.tag == "Rajahdys")
        {
            //blood.Play();
            Debug.Log("OmaPommi");
        }
    }

    public void Sarjatuli()
    {
        float fireRate = 0.25f;
        float nextFire = 0.1f;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

            nextFire = Time.time + fireRate;
        }


    }
}
