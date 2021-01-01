using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUnusedCircles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        GameManager.instance.InstantiateCircles();
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    collision.gameObject.SetActive(false);

    //}
}
