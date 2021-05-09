using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLiikkuminenVOL3 : MonoBehaviour
{

    public float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float runSpeed;

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

    public bool canShoot = true;
    public bool canThrow = true;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputaxis.x = Input.GetAxisRaw("Horizontal");
        inputaxis.y = Input.GetAxisRaw("Vertical");
        inputaxis.Normalize();

        ukkodirection();

       // if ((inputaxis.x != 0) && (inputaxis.y != 0))
       // {
       //    ukkodirection();
       // }

        if (Input.GetButton("Fire1") && (canShoot = true))
        {
            shoot();
        }

        else if (Input.GetButton("Fire2"))
        {
            sprint();
        }

        else if (Input.GetButtonDown("Fire3") && (canThrow = true))
        {
            grenade();
        }

        else 
        {
            idle();
        }
       
    }

    private void ukkodirection()
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

    private void shoot()
    {
        canThrow = false;

        if (inputaxis.x == 0 && inputaxis.y == 0)
        {
            MyAnimator.SetFloat("Speed", 1.33f);
            if (Time.time > lastFire)
            {
                lastFire = Time.time + fireRate;
                Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
                shotIndex++;
                if (shotIndex > 2)
                    shotIndex = 0;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                MyAnimator.SetFloat("Speed", 0f);
            }

        }

        else

        { 
        MyAnimator.SetFloat("Speed", 0.33f);
        speed = walkSpeed;
        if (Time.time > lastFire)
        {
            lastFire = Time.time + fireRate;
            Instantiate(bullet, sarjaSpawn[shotIndex].transform.position, sarjaSpawn[shotIndex].transform.rotation);
            shotIndex++;
            if (shotIndex > 2)
                shotIndex = 0;
        }
        if (Input.GetButtonUp("Fire1"))
            {
            speed = runSpeed;
            MyAnimator.SetFloat("Speed", 0.66f);
            }
        }
    }

    private void sprint()
    {
        canShoot = false;
        canThrow = false;

        MyAnimator.SetFloat("Speed", 1f);
        speed = sprintSpeed;
        if (Input.GetButtonUp("Fire2"))
            {
            speed = runSpeed;
            MyAnimator.SetFloat("Speed", 0.66f);
            }
    }

    private void grenade()
    {
        canShoot = false;

        if (inputaxis.x == 0 || inputaxis.y == 0)
        {
            MyAnimator.SetFloat("Speed", 1.66f);
            granuLastFire = Time.time + granuFireRate;
            Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);
            canThrow = false;
        }
        else
        {
            MyAnimator.SetFloat("Speed", 2f);
            speed = walkSpeed;
            granuLastFire = Time.time + granuFireRate;
            Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);
            canThrow = false;
        }

        if (Input.GetButtonUp("Fire3"))
        {
            speed = runSpeed;
            MyAnimator.SetFloat("Speed", 0.66f);
            canThrow = true;
            canShoot = true;
        }
    }

    void idle()
    {
        MyAnimator.SetFloat("Speed", 0f);
    }
}
