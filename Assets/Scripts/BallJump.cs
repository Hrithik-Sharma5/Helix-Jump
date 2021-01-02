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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y > 18)
        {
            Collider[] hitcollider = Physics.OverlapSphere(transform.position, 2);
            foreach (var item in hitcollider)
            {
                if (item.gameObject.tag == "Ground") item.gameObject.SetActive(false);
            }
            return;
        }
        if (collision.gameObject.tag == "Ground")
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Obsticle")
        {
            rb.isKinematic = true;
            GameManager.instance.GameOver();
        }
    }


}
