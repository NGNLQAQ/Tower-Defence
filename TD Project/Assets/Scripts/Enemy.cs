using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    private Transform[] points;
    private int index = 0;
    void Start()
    {
        points = Waypoints.points;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (index > points.Length - 1) return;
        transform.Translate((points[index].position - this.transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(points[index].position, this.transform.position) < 0.2f)
        {
            index++;
        }
        if (index > points.Length - 1)
        {
            ReachEnd();
        }
    }

    void ReachEnd()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        SpawnEnemy.enemycount--;
    }
}
