using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    float speed = 1.0f;
    float distance = 10.0f;

    float spawnArea = 8.0f;

    Vector3 randomPos;
    Vector3 mRandomPos;

    Vector3 randomPt;
    Vector3 dir;
    Vector3 moveDir;
    Vector3 moveToPos;

    private void Awake()
    {
        randomPos = Random.insideUnitCircle;
        mRandomPos = new Vector3(randomPos.x, 0.0f, randomPos.y);
        transform.position = mRandomPos * spawnArea;
    }

    void Start()
    {
        randomPt = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        dir = randomPt - transform.position;
        moveDir = dir.normalized * distance;
        moveToPos = transform.position + moveDir;
    }

    void Update()
    {
        transform.position += moveToPos * Time.deltaTime * speed;
    }
}
