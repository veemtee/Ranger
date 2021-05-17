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

    private void Start()
    {
        UralCurrentHealth = UralMaxHealth;
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

            UralCurrentHealth--;
            
        }
    }

    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }
}
