using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UralTakingDamageScript : MonoBehaviour
{
    public GameObject raato;

    public int UralMaxHealth;
    public int UralCurrentHealth;
    public bool deadorAlive = false;
    //public Gamemanager gameManager;
    public ParticleSystem explosion;

    public AudioClip[] hitSound;
    private AudioSource audiosource;
    private AudioClip soitettava;

    private void Start()
    {
        UralCurrentHealth = UralMaxHealth;
        audiosource = gameObject.GetComponent<AudioSource>();
        //gameManager = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    private void Update()
    {
        if (UralCurrentHealth <= 0)
        {
           

            if (deadorAlive == false)
            {
                Debug.Log("deadoralive false");
                deadorAlive = true;
                Instantiate(explosion.gameObject, transform.position, transform.rotation);
                explosion.Play();

                //gameManager.ScoreCount(1000);
                Instantiate(raato.gameObject, transform.position, transform.rotation);
                
                Invoke("Tuhoutuminen", 0.0f);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("UralOsuma");
            int index = Random.Range(0, hitSound.Length);
            soitettava = hitSound[index];
            audiosource.clip = soitettava;
            audiosource.PlayOneShot(soitettava);
            UralCurrentHealth--;
            
        }
    }

    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }
}
