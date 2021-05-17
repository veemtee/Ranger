using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnausRekasta : MonoBehaviour
{

    public GameObject vihu1;
    public float timer;
    //private float adjustedTimer;
    public int spawnAmount;
    public int laskuri;
    public float alkuDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnAmounttia", alkuDelay);
    }

    void Update()
    {
       
    }

    void spawnAmounttia()
    {

        InvokeRepeating("SpawnaaVihu", timer, timer);
        
    }

 
    void SpawnaaVihu()
    {

        laskuri++;
        Instantiate(vihu1.gameObject, transform.position, transform.rotation);
        if (laskuri >= spawnAmount)
        {
            CancelInvoke();
        }
        

    }
}


