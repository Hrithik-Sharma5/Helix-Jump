using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    [SerializeField]Transform mainCam;
    [SerializeField]Transform ballToFollow;

    // Update is called once per frame
    void Update()
    {
        if(mainCam.position.y> ballToFollow.position.y)
        {
            mainCam.position = new Vector3(0, ballToFollow.position.y, 0);
        }
    }
}
