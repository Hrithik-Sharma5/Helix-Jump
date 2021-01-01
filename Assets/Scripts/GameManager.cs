using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject[] circlePrefab;
    [SerializeField] List<GameObject> circlesInScene = new List<GameObject>();
    [SerializeField] Transform circleContainer;
    float startYpos = -10.4f;
    float tempYpos;
    float distanceBetweenCircles = -5;
    
    void Start()
    {
        instance = this;
        Time.timeScale = 1.5f;
        tempYpos = startYpos;
        for (int i = 0; i < circlePrefab.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject circle = Instantiate(circlePrefab[i], Vector3.zero, Quaternion.Euler(-90,Random.Range(0,360),0), circleContainer);
                circlesInScene.Add(circle);
                circle.SetActive(false);
            }
            
        }
        for (int i = 0; i < 12; i++)
        {
            InstantiateCircles();
        }
    }

    public void InstantiateCircles()
    {
        GameObject obj = CirclePool();
        obj.SetActive(true);
        obj.transform.localPosition = new Vector3(0, tempYpos, 0);
        tempYpos += distanceBetweenCircles;
    }

    GameObject CirclePool()
    {
        numChoose:
        int circleNum = Random.Range(0, circlesInScene.Count);
        if (!circlesInScene[circleNum].activeSelf)
        {
            return circlesInScene[circleNum];
        }
        else
            goto numChoose;

       // return null;
    }
}
