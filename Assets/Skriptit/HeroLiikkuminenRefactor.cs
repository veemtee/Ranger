using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLiikkuminenRefactor : MonoBehaviour
{
    public float speed;
    public float walkSpeed;
    public float sprintSpeed;
    Animator MyAnimator;
    public Rigidbody playerRb;
    Vector2 inputaxis;
    private float lastFire = 0.0f;
    public float fireRate;
    public GameObject bullet;
    public GameObject granu;
    public GameObject[] sarjaSpawn;
    public GameObject granuSpawn;
    int shotIndex = 0;

    private float granuLastFire = 0.0f;
    public float granuFireRate;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputaxis.x);
        Debug.Log(inputaxis.y);

        MyAnimator.SetFloat("Speed", 0);

        inputaxis.x = Input.GetAxisRaw("Horizontal");
        inputaxis.y = Input.GetAxisRaw("Vertical");
        inputaxis.Normalize();

        if (inputaxis.x != 0 || inputaxis.y != 0)
        {
            run();
        }

        if (Input.GetButton("Fire1") && (inputaxis.x != 0 || inputaxis.y != 0) )
        {
            runAndShoot();
        }

        if (Input.GetButton("Fire1") && (inputaxis.x == 0 || inputaxis.y == 0))
        {
            shootInPlace();
        }

        if (Input.GetButton("Fire2") && (inputaxis.x != 0 || inputaxis.y != 0))
        {
            sprint();
        }

        if (Input.GetButton("Fire3") && (inputaxis.x == 0 || inputaxis.y == 0))
        {
            grenadeInPlace();
        }
    }

    private void run()
    {
        if (inputaxis.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.y == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.y == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 315, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 135, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 225, 0);
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 0.66f);
        }
    }

    private void runAndShoot()
    {
        MyAnimator.SetFloat("Speed", 0.33f);

        if (Time.time > lastFire)
        {
            //MyAnimator.SetTrigger("Shooting");
            //fireRate = 0.12f;
            //float lastfire = 0.1f;

            speed = 20.0f;
            lastFire = Time.time + fireRate;
            Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
            //suuliekki.Play();
            shotIndex++;
            if (shotIndex > 2)
                shotIndex = 0;
        }

        if (inputaxis.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            
        }

        if (inputaxis.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.y == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.y == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 315, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 135, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
           // MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 225, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }
    }

    private void sprint()
    {
        if (inputaxis.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.y == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.y == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 315, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 135, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 225, 0);
            playerRb.transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            MyAnimator.SetFloat("Speed", 1f);
        }
    }

    private void runGrenade()
    {
        MyAnimator.SetFloat("Speed", 3.33f);
        //Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);

        if (Time.time > granuLastFire)
        {
            
            granuLastFire = Time.time + granuFireRate;
            Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);
            
        }

        if (inputaxis.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

        }

        if (inputaxis.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.y == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.y == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y >= 0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 315, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x >= 0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 135, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            // MyAnimator.SetFloat("Speed", 0.33f);
        }

        if (inputaxis.x <= -0.68 && inputaxis.y <= -0.68)
        {
            transform.localRotation = Quaternion.Euler(0, 225, 0);
            playerRb.transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            //MyAnimator.SetFloat("Speed", 0.33f);
        }
    }

    private void shootInPlace()
    {
        MyAnimator.SetFloat("Speed", 1.33f);
        lastFire = Time.time + fireRate;
        Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
        shotIndex++;
        if (shotIndex > 2)
            shotIndex = 0;
    }

    private void grenadeInPlace()
    {
        MyAnimator.SetFloat("Speed", 2f); 
        granuLastFire = Time.time + granuFireRate;
        Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);
    }
}
