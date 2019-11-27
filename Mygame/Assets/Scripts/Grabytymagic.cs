using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabytymagic : MonoBehaviour
{
    public GameObject tama;

    public GameObject tamaPlefab;
   

    private void OnCollisionEnter(Collision collision)
    {
        Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f); //n秒後に消える

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            tama = Instantiate(tamaPlefab, transform.position + transform.forward * 10f + transform.up * 1, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tama = Instantiate(tamaPlefab, transform.position + transform.forward * 10f + transform.up * 1, transform.rotation);
        }
    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().velocity = transform.forward * 300 * Time.fixedDeltaTime;
    }    
}
