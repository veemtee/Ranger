using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpetsMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool runOrNotToRun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (runOrNotToRun == true)
        {
            
            rb.velocity = transform.forward * Time.deltaTime * speed;
        }
    }
}
