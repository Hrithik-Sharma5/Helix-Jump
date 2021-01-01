using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    [SerializeField]Transform mainCam;
    [SerializeField]Transform ballToFollow;
    [SerializeField] Transform middleCylender;
    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.y < -16 && mainCam.position.y > -20) middleCylender.parent = mainCam;
        if(mainCam.position.y> ballToFollow.position.y)
        {
            mainCam.position = new Vector3(0, ballToFollow.position.y, 0);
        }
    }
}
