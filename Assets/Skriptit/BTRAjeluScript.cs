using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRAjeluScript : MonoBehaviour
{
    private Rigidbody btrRb;
    public float moveSpeed;
    public float stoppingDistance;
    public float retreatDistance;
    private GameObject hero;
    private Rigidbody heroRb;

    // Start is called before the first frame update
    void Start()
    {
        btrRb = GetComponent<Rigidbody>();
        hero = GameObject.Find("Hero");
        heroRb = hero.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //pitäis saada btr hakemaan heron positio ja sitten kääntyä heroa päin 45 asteen kulmissa mutta sensijaan että suoraan kohti pitäis kiertää hieman

        //eli mitä haluttas ois heroa kohti ajeleva tankki joka tietyn matkan päässä alkaa ampua sarjaa ja spawnata ukkoa, pysähtyy siihen pisteeseen, ois gudenuff basic vielä jos object avoidance tutorialista ni voila

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 heroDirection = transform.position - hero.transform.position;
        float angle = Mathf.Atan2(heroDirection.z, heroDirection.x) * Mathf.Rad2Deg;
        transform.LookAt(hero.transform.position);
        float adjustedAngle = Mathf.Round(((angle + 90f) * -1) / 45.0f) * 45.0f;
        transform.localRotation = Quaternion.Euler(0, adjustedAngle, 0);
        /*
        if (Vector2.Distance(transform.position, heroRb.position) > stoppingDistance)
        {
            btrRb.velocity = (transform.forward * moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, heroRb.position) < stoppingDistance && Vector2.Distance(transform.position, heroRb.position) >retreatDistance)
        {
            btrRb.velocity = (transform.forward * -moveSpeed * Time.deltaTime);
        }

       */
    }
}
