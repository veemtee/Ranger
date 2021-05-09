using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public int offsetValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position.z <= (target.position.z + offsetValue))
        {
            transform.position = new Vector3(0, transform.position.y, target.transform.position.z + offsetValue);
        }
    }
}
