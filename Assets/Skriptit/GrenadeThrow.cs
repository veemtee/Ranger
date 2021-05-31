using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    public float force;
    public GameObject spawn;
    public Rigidbody rigid;
    public GameObject granu;
    

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody grenadeRb = GetComponent<Rigidbody>();
        //grenadeRb.AddForce(transform.forward * force);
       /* if (Input.GetButtonDown("Fire3") )
        {
            Instantiate(granu, spawn.transform.position, spawn.transform.rotation);
        } */
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GranuSpawn()
    {
        Debug.Log("granuspawniin");
        Instantiate(granu, spawn.transform.position, spawn.transform.rotation);
        Debug.Log("InstaaGranu");
        granu.transform.parent = spawn.transform;
        rigid.useGravity = false;
    }

    public void GranuLentoon()
    {
        Debug.Log("ranulennossa");
        granu.transform.parent = null;
        rigid.useGravity = true;
        transform.rotation = spawn.transform.rotation;
        rigid.AddForce(transform.forward * force);
    }
}
