using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    KeyCode forward = KeyCode.W;

    [SerializeField]
    KeyCode back = KeyCode.S;

    [SerializeField]
    KeyCode right = KeyCode.A;

    [SerializeField]
    KeyCode left = KeyCode.D;

    float move = 0f;
    float steering = 0f;
    float jump = 100f;

    Animator animator;

    public GameObject tama;

    public GameObject tamaPlefab;



    private void Start()
    {
        this.animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(this.forward))
        {
            this.move = 1;
        }
        else if (Input.GetKey(this.back))
        {
            this.move = -1;
        }
        else
        {
            this.move = 0;
        }

        if (Input.GetKey(this.right))
        {
            this.steering = 1;
        }
        else if (Input.GetKey(this.left))
        {
            this.steering = -1;
        }
        else
        {
            this.steering = 0;
        }

        //アナログ
        this.move = Input.GetAxis("LeftStickvetical");
        this.steering = Input.GetAxis("LeftStickHorizontal");

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            tama = Instantiate(tamaPlefab, transform.position + transform.forward * 10f + transform.up * 1, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  tama = Instantiate(tamaPlefab, transform.position + transform.forward * 10f + transform.up * 1, transform.rotation);
        }



    }

    public float Move()
    {
        return this.move;
    }

    public float Steering()
    {
        return this.steering;
    }

}

