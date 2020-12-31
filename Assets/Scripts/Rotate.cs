using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float mouseOffset;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseOffset = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, -mouseOffset*Time.deltaTime*300,0));
        }       
    }
}
