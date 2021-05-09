using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovTutorial : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    public float sprintSpeed;

    private Vector3 movedirection;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {

    }
}
