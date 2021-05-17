using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuscaleRelease : MonoBehaviour
{
    GrenadeThrow grenthrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBalllia()
    {
        Debug.Log("ThrowBall");
        grenthrow = GameObject.FindGameObjectWithTag("HeroGranu").GetComponent<GrenadeThrow>();
        grenthrow.GranuLentoon();
    }

}
