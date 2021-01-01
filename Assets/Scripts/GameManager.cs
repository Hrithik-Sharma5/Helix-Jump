using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] circlePrefab;
    [SerializeField] List<GameObject> circlesInScene = new List<GameObject>();
    [SerializeField] Transform circleContainer;
    float startYpos = -10.4f;
    float tempYpos;
    float distanceBetweenCircles = -5;
    
    void Start()
    {
        tempYpos = startYpos;
        for (int i = 0; i < 20; i++)
        {
            GameObject circle = Instantiate(circlePrefab[0], Vector3.zero, circlePrefab[0].transform.rotation, circleContainer);
            circlesInScene.Add(circle);
            circle.SetActive(false);
        }
        for (int i = 0; i < 6; i++)
        {
            InstantiateCircles();
        }
    }

    void InstantiateCircles()
    {
        GameObject obj = CirclePool();
        obj.SetActive(true);
        obj.transform.localPosition = new Vector3(0, tempYpos, 0);
        tempYpos += distanceBetweenCircles;
    }

    GameObject CirclePool()
    {
        foreach (GameObject item in circlesInScene)
        {
            if (!item.activeSelf) return item;
        }
        return null;
    }
}
