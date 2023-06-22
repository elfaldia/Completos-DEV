using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_Controller : MonoBehaviour
{
    private float minX, minY, maxX, maxY;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private GameObject [] enemies;
    [SerializeField]
    private float time;

    private float nextTime;

    void Start()
    {
        maxX = points.Max(point => point.position.x);
        minX = points.Min(point => point.position.x);
        maxY = points.Max(point => point.position.y);
        minY = points.Min(point => point.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        nextTime += Time.deltaTime;

        if(nextTime >= time)
        {
            nextTime = 0;
            SummonEnemy();
        }
    }
    void SummonEnemy()
    {
        int enemy = Random.Range(0, 6);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemies[enemy], randomPosition, Quaternion.identity);
    }
}
