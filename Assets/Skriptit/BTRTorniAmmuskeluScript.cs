using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRTorniAmmuskeluScript : MonoBehaviour
{
    private GameObject hero;
    private Rigidbody heroRb;
    public GameObject bullet;
    public GameObject btrTorni;
    public float timeBetweenShots;
    public float startTimeBtwShots;
    public GameObject bulletSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Player");
        heroRb = hero.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        btrTorni.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 heroDirection = transform.position - hero.transform.position;
        float angle = Mathf.Atan2(heroDirection.z, heroDirection.x) * Mathf.Rad2Deg;
        transform.LookAt(heroDirection);
        float adjustedAngle = Mathf.Round(((angle + 90f) * -1) / 45.0f) * 45.0f;
        transform.localRotation = Quaternion.Euler(0, adjustedAngle, 0);


        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            timeBetweenShots = startTimeBtwShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }
}
