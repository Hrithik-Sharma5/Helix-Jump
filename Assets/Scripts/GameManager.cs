using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]public bool canRotate=false;
    [SerializeField] GameObject[] circlePrefab;
    [SerializeField] List<GameObject> circlesInScene = new List<GameObject>();
    [SerializeField] Transform circleContainer;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject cylinder;
    float startYpos = -10.4f;
    float tempYpos;
    float distanceBetweenCircles = -5;
    static bool firstPlayDone;

    void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(this.gameObject);

        if (firstPlayDone)
        {
            StartGame();
        }
        else
        {
            UIManager.instance.UIState(true);
        }

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

        InstantiateFirstCircle();

        for (int i = 0; i < 12; i++)
        {
            InstantiateCircles();
        }
    }

    void InstantiateFirstCircle()
    {
        circlesInScene[0].SetActive(true);
        circlesInScene[0].transform.localPosition = new Vector3(0, tempYpos, 0);
        tempYpos += distanceBetweenCircles;
    }

    //public IEnumerator InstantiateCircles()
    //{
    //    GameObject obj = CirclePool();
    //    obj.SetActive(true);
    //    obj.transform.localPosition = new Vector3(0, tempYpos, 0);
    //    activeCircles++;
    //    tempYpos += distanceBetweenCircles;
    //    yield return null;
    //}

    public void OnTapScreenToPlay()
    {
        if (!firstPlayDone)
        {
            StartGame();
            firstPlayDone = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void StartGame()
    {
        cylinder.GetComponent<Animator>().enabled = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        canRotate = true;
        if(!firstPlayDone)UIManager.instance.HideUI();
    }

    public void InstantiateCircles()
    {
        GameObject obj = Instantiate(circlePrefab[Random.Range(0, circlePrefab.Length)],circleContainer);
        obj.transform.rotation = Quaternion.Euler(-90, 0, Random.Range(0, 360));
        obj.SetActive(true);
        obj.transform.localPosition = new Vector3(0, tempYpos, 0);
        tempYpos += distanceBetweenCircles;
    }

    public void GameOver()
    {
        canRotate = false;
        UIManager.instance.ShowUI();
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
