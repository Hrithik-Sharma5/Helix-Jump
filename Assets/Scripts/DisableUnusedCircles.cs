using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUnusedCircles : MonoBehaviour
{
    bool canCollide=true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Ground") return;
        if (other.gameObject.GetComponent<BoxCollider>() == null) return;

        Destroy(other.gameObject);

        //other.gameObject.SetActive(false);
        //GameManager.instance.activeCircles--;
        GameManager.instance.InstantiateCircles() ;
    }


}
