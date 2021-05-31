using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RagdollScriptiä : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject animated;
    public NavMeshAgent agent;
    private bool dead;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    public ParticleSystem blood;
    public AudioClip[] gruntSound;
    private AudioSource audiosource;
    private AudioClip soitettava;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll.gameObject.SetActive(false);
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleDead()
    {
        dead = !dead;

        if(dead)
        {
            int index = Random.Range(0, gruntSound.Length);
            soitettava = gruntSound[index];
            audiosource.clip = soitettava;
            audiosource.Play();

            CopyTransformData(animated.transform, ragdoll.transform, agent.velocity);
            ragdoll.gameObject.SetActive(true);
            animated.gameObject.SetActive(false);
            Destroy(animated.gameObject);
            agent.enabled = false;

            foreach(Rigidbody rb in ragdollBodies)
            {
                rb.AddExplosionForce(107f, new Vector3(-1f, 0.5f, -1f), 5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeroDamage"))
        {

            Vector3 triggerPosition = other.ClosestPointOnBounds(transform.position);
            Vector3 direction = triggerPosition - transform.position;

            Instantiate(blood, triggerPosition, Quaternion.LookRotation(direction));

            ToggleDead();
        }

    }

    private void CopyTransformData(Transform sourceTransform, Transform destinationT, Vector3 velocity)
    {
        if (sourceTransform.childCount != destinationT.childCount)
        {
            Debug.LogWarning("transformitvituillaan");
            return;
        }

        for (int i = 0; i < sourceTransform.childCount; i++)
        {
            var source = sourceTransform.GetChild(i);
            var destination = destinationT.GetChild(i);
            destination.position = source.position;
            destination.rotation = destination.rotation;
            var rb = destination.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = velocity;

            CopyTransformData(source, destination, velocity);
        }
    }
}
