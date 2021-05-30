﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barracksDamageScript : MonoBehaviour
{
    public int btrMaxHealth;
    public int btrCurrentHealth;

    public GameObject Raato;
    public bool deadorAlive = false;
    public GameObject isoRajahdys;

    public AudioClip[] damageSound;
    private AudioSource audiosource;
    private AudioClip soitettava;

    //public GameObject keulaPanssariTrigger;
    //public GameObject muuPanssariTrigger;

    private void Start()
    {
        btrCurrentHealth = btrMaxHealth;
    }

    private void Update()
    {
        if (btrCurrentHealth <= 0)
        {
            if (deadorAlive == false)
            {
                Instantiate(isoRajahdys.gameObject, transform.position, transform.rotation);
                Instantiate(Raato.gameObject, transform.position, transform.rotation);
                Invoke("Tuhoutuminen", 0.0f);
            }
        }
    }



    void Tuhoutuminen()
    {
        Destroy(gameObject);
    }
}
