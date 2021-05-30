using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeulaPanssariSkript : MonoBehaviour
{

    public BTR_DamageScript DamageSkript;
    public GameObject ricochet;
    public AudioClip[] damageSound;
    private AudioSource audiosource;
    private AudioClip soitettava;

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
            int index = Random.Range(0, damageSound.Length);
            soitettava = damageSound[index];
            audiosource.clip = soitettava;
            audiosource.Play();
            Instantiate(ricochet, other.transform.position, other.transform.rotation);

        }

        if (other.tag == "HeroGranu")
        {
            Debug.Log("kranuOsu");

            DamageSkript.btrCurrentHealth = -10;
        }
    }
}
