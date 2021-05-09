using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihu2 : MonoBehaviour
{

    public SpetsMovement spetsmovementScript;
    
    public Collider enemySensor;
    public Transform hero;

    public GameObject bulletSpawn;
    public GameObject bullet;

    bool thereisbullet;
    public GameObject imthebullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (imthebullet == null)
        {
            thereisbullet = false;
        }
    }

    void FaceEnemy()
    {
        transform.LookAt(hero);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            FaceEnemy();
            Take_a_Shot();
            RuntoPlayer();
        }
    }

    public void Take_a_Shot()
    {
        if (thereisbullet == false)
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            this.bullet = imthebullet;
            thereisbullet = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeroClose")
        {
            RunOrFlank();
        }
    }

    void RunOrFlank()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - hero.position);
    }

    void RuntoPlayer()
    {
        Debug.Log("runto");
        spetsmovementScript.runOrNotToRun = true; 
    }
}
