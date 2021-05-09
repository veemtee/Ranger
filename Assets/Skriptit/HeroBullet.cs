using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    private Rigidbody bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        //FindObjectOfType<AudioManager>().Play("Rynkky1");
        Invoke("SelfDestruct", 3.0f);
        //Physics.IgnoreLayerCollision(9, 11);
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = (transform.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {


        Destroy(gameObject);

    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
