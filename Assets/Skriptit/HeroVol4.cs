using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVol4 : MonoBehaviour
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

    GrenadeThrow grenadeThrow;

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


        if (inputaxis.x != 0 || inputaxis.y != 0)
        {
            Debug.Log("mennään directioniin");
            ukkodirection();
        }
            

        if (Input.GetButton("Fire1") && (canShoot = true))
        {
            shoot();
        }

        else if (Input.GetButton("Fire2"))  // && (inputaxis.x != 0 && inputaxis.y != 0)) 
        {
            sprint();
        }

        else if (Input.GetButtonDown("Fire3") && (canThrow = true))
        {
            grenade();
        }

        if (inputaxis.x == 0 && inputaxis.y == 0 && Input.GetButton("Fire1") == false)
        {
            Debug.Log("idleen");
            idle();
        }
        //else
        //{
        //    idle();
        //}

    }

    private void SetDirection(float xDir, float yDir, float zDir)
    {
        transform.localRotation = Quaternion.Euler(xDir, yDir, zDir);
        playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void ukkodirection()
    {
        //if (inputaxis.x == 0 && inputaxis.y == 0)
        //{
        //   MyAnimator.SetFloat("Speed", 0f);
        //}
        //if (inputaxis.x != 0 || inputaxis.y !=0)
        //{
        //MyAnimator.SetFloat("Speed", 1f);
        Debug.Log("normijuoksu");
        MyAnimator.SetFloat("Speed", 1f);
            SetDirection(0, CalculateAngle(inputaxis.x, inputaxis.y), 0);
        Debug.Log("loppudirection");
        //}
    }
    
    private float CalculateAngle(float inpX, float inpY)
    {
        float angle;
        if (inpY > 0)
        {
            angle = (360f + (Vector3.SignedAngle(Vector3.right, new Vector3(inpX, inpY, 0f), Vector3.up)) * -1);
        }
        else
        {
            angle = (Vector3.SignedAngle(Vector3.right, new Vector3(inpX, inpY, 0f), Vector3.up));
        }
        angle = (angle + 90) % 360;
        return angle;
    }

    private void shoot()
    {
        canThrow = false;

        if (inputaxis.x == 0 && inputaxis.y == 0)
        {
            Debug.Log("shootinplace");
            MyAnimator.SetFloat("Speed", 0.15f);
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
                //MyAnimator.SetFloat("Speed", 0.7f);
                //ukkodirection();
            }
            
        }

        else

        {
            MyAnimator.SetFloat("Speed", 0.665f);
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
                //MyAnimator.SetFloat("Speed", 0.66f);
                ukkodirection();
            }
        }
    }

    private void sprint()
    {
        canShoot = false;
        canThrow = false;

        MyAnimator.SetFloat("Speed", 1.33f);
        speed = sprintSpeed;
        if (Input.GetButtonUp("Fire2"))
        {
            speed = runSpeed;
            MyAnimator.SetFloat("Speed", 1f);
        }
    }

    private void grenade()
    {
        
        canShoot = false;
        MyAnimator.SetTrigger("Granu");
        Debug.Log("heittokutsuikoPRE");
        GameObject grenade = Instantiate(granu, granuSpawn.transform.position, granuSpawn.transform.rotation);
        grenadeThrow = grenade.GetComponent<GrenadeThrow>(); //GameObject.FindGameObjectWithTag("HeroGranu").GetComponent<GrenadeThrow>();
        grenadeThrow.GranuSpawn();
        Debug.Log("heittokutsuiko");
        //Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);

        /*  if (inputaxis.x == 0 || inputaxis.y == 0)
          {
              MyAnimator.SetFloat("Speed", 0.2f);
              granuLastFire = Time.time + granuFireRate;
              Instantiate(granu, granuSpawn.transform.position, sarjaSpawn[shotIndex].transform.rotation);
              canThrow = false;
          }
          else
          {
              MyAnimator.SetTrigger("RunGrenade");
              speed = walkSpeed;
              MyAnimator.SetFloat("Speed", 0.5f);
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
          }  */
    }

    void idle()
    {
        MyAnimator.SetFloat("Speed", 0f);
    }
}
