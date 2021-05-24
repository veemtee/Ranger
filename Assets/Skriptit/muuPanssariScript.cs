using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muuPanssariScript : MonoBehaviour
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
        if (other.tag == "HeroDamage")
        {
            Debug.Log("LuotiOsuPerään");

            DamageSkript.btrCurrentHealth--;

        }

        if (other.tag == "HeroGranu")
        {
            Debug.Log("kranuOsuPerään");
            DamageSkript.btrCurrentHealth = -31;
        }
    }
}
