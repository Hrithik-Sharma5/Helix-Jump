using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]float rotationSpeed = 300;
    float mouseOffset;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseOffset = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, -mouseOffset*Time.deltaTime*rotationSpeed,0));
        }       
    }
}
