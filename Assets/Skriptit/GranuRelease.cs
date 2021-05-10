using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuRelease : MonoBehaviour
{
    //public GameObject granu;
    //GranuSkript granuScript;
    //public GameObject spawn;
    //Rigidbody granunRb;
    GrenadeScript grenthrow;
    public GameObject granu;
    public GameObject granuSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
        //Instantiate(granu, spawn.transform.position, spawn.transform.rotation);
        //granu.transform.position = spawn.transform.position;
        //granunRb = granu.GetComponent<Rigidbody>();
        //granunRb.useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBall()
    {
        //grenthrow = GameObject.FindGameObjectWithTag("HeroGranu").GetComponent<GrenadeThrow>();
        Debug.Log("ThrowBall");
        Instantiate(granu, granuSpawn.transform.position, granuSpawn.transform.rotation);
        grenthrow = granu.GetComponent<GrenadeScript>();
        //grenthrow = GameObject.FindGameObjectWithTag("HeroGranu").GetComponent<GrenadeThrow>();
        grenthrow.GranuLentoon();
        Debug.Log("ThrowBall2");
        //granuScript = granu.GetComponent<GrenadeThrow>();
        //granuScript.ReleaseMe();
    }
}
