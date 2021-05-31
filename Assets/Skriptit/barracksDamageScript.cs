using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barracksDamageScript : MonoBehaviour
{
    public int btrMaxHealth;
    public int btrCurrentHealth;

    public GameObject Raato;
    public bool deadorAlive = false;
    public GameObject isoRajahdys;

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
                audiosource.PlayOneShot(possaus, 1f);
                audiosource.PlayOneShot(pamaus, 1f);
                Instantiate(isoRajahdys.gameObject, transform.position, transform.rotation);
                Instantiate(Raato.gameObject, transform.position, transform.rotation);
                Invoke("Tuhoutuminen", 1f);
            }
        }
    }



    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }
}
