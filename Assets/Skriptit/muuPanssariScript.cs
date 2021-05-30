﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muuPanssariScript : MonoBehaviour
{
    public barracksDamageScript DamageSkript;
    public GameObject ricochet;
    //public AudioClip hitsound;
    public AudioSource audiosource;
    //public AudioClip ricSound;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeroDamage")
        {
            Debug.Log("LuotiOsuPerään");
            Instantiate(ricochet, other.transform.position, other.transform.rotation);

            DamageSkript.btrCurrentHealth--;

        }

        if (other.tag == "HeroGranu")
        {
            Debug.Log("kranuOsuPerään");
            DamageSkript.btrCurrentHealth = -31;
        }
    }
}
