using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeulaPanssariSkript : MonoBehaviour
{

    public BTR_DamageScript DamageSkript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("osuuko");

            

        }

        if (other.tag == "HeroGranu")
        {
            Debug.Log("kranuOsu");

            DamageSkript.btrCurrentHealth = -10;
        }
    }
}
