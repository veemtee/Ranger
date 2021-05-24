using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_DamageScript : MonoBehaviour
{

    public int btrMaxHealth;
    public int btrCurrentHealth;

    public GameObject Raato;
    public bool deadorAlive = false;

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
