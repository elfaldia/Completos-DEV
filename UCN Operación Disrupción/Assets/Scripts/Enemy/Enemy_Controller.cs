using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy_Controller : MonoBehaviour
{
    private float minX, minY, maxX, maxY, maxXBoss, minXBoss, maxYBoss, minYBoss;
    [SerializeField]
    private Transform[] points, pointsBoss;
    [SerializeField]
    private GameObject [] enemies;

    void Start()
    {
        maxX = points.Max(point => point.position.x);
        minX = points.Min(point => point.position.x);
        maxY = points.Max(point => point.position.y);
        minY = points.Min(point => point.position.y);
        maxXBoss = pointsBoss.Max(point => point.position.x);
        minXBoss = pointsBoss.Min(point => point.position.x);
        maxYBoss = pointsBoss.Max(point => point.position.y);
        minYBoss = pointsBoss.Min(point => point.position.y);

        for(int i = 0; i < Random.Range(2,6) ; i++) {
                Invoke("SummonEnemy", 0);
        }

        Invoke("SummonBoss", 30f);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void SummonEnemy()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemies[0], randomPosition, Quaternion.identity);
    }
    void SummonBoss()
    {
        Vector2 randomPositionBoss = new Vector2(Random.Range(minXBoss, maxXBoss), Random.Range(minYBoss, maxYBoss));
        Instantiate(enemies[1], randomPositionBoss, Quaternion.identity);
    }
}
