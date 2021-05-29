using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UralVaakaAjoScript : MonoBehaviour
{
    public float speed;
    public AudioClip moottori;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        audiosource.PlayOneShot(moottori, 1f);
    }
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
