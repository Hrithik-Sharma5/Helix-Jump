using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //Debug.Log("1");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            Time.timeScale = 0;
        }
    }


}
