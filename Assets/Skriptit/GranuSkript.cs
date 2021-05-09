using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuSkript : MonoBehaviour
{
    public float kranuSpeed;
    public GameObject sirpalePrefab;
    public float heittoajastin;
    public Rigidbody Kranu;
    public GameObject rajahdysPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kranunheitto", heittoajastin);
    }
    
    private void Kranunheitto()
    {
        Kranu.velocity = (Kranu.transform.forward * kranuSpeed * Time.deltaTime + Kranu.transform.up * kranuSpeed/3 * Time.deltaTime);
        //GetComponent<Rigidbody>().velocity = (transform.forward * kranuSpeed * Time.deltaTime + transform.up * kranuSpeed / 1.5f * Time.deltaTime);
        Invoke("SelfDestruct", 3f);
    }

    private void SelfDestruct()
    {
        Invoke("Sirpaleet", 0f);
        Instantiate(rajahdysPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Sirpaleet()
    {
        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 1:
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 2:
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 3:
                    transform.localRotation = Quaternion.Euler(0, 270, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;

                case 4:
                    transform.localRotation = Quaternion.Euler(0, 45, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 5:
                    transform.localRotation = Quaternion.Euler(0, 135, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 6:
                    transform.localRotation = Quaternion.Euler(0, 215, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
                case 7:
                    transform.localRotation = Quaternion.Euler(0, 315, 0);
                    Instantiate(sirpalePrefab, transform.position, transform.localRotation);
                    break;
            }
        }
    }

}
