using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_DamageScript : MonoBehaviour
{

    public int btrMaxHealth;
    public int btrCurrentHealth;

    public GameObject Raato;
    public bool deadorAlive = false;

    public AudioClip possaus;
    public AudioClip pamaus;
    private AudioSource audiosource;
    //public GameObject keulaPanssariTrigger;
    //public GameObject muuPanssariTrigger;

    private void Start()
    {
        btrCurrentHealth = btrMaxHealth;
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (btrCurrentHealth <= 0)
        {
            if (deadorAlive == false)
            {
                audiosource.PlayOneShot(possaus, 2f);
                audiosource.PlayOneShot(pamaus, 1.5f);
                Instantiate(Raato.gameObject, transform.position, transform.rotation);
                Invoke("Tuhoutuminen", 0.2f);
            }
        }
    }

    

    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }
}
