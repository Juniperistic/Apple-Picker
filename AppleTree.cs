using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;

    //public List<GameObject> speedList;
    //public List<GameObject> chanceToChangDirections;
    //public List<GameObject> secondsBetweenAppleDrops;

    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f);

        //speedList = new List<GameObject>();
        //for (int i = 0)
        //{
        //    speed = 1f;
        //}

        //for (int i = 1)
        //{
        //     speed = 2f;
        //}

        //chanceToChangeDirections = new List<GameObject>();
        //for (int i = 0)
        //{
        //chanceToChangeDirections = 0.1f
        //}

        //for (int i =1)
        //{
        //chanceToChangeDirections = 0.2f
        //}

        //secondsBetweenAppleDrops = new List<GameObject>();

        //for (int i = 0)
        //{
        //secondsBetweenAppleDrops = 1f;
        //}

        //for (int i = 1)
        //{
        //secondsBetweenAppleDrops = 0.5f;
        //}

    }


    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void fixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

}

