using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> wayPoints;
    [SerializeField] WaveConfig waveConfig;
    [SerializeField] float moveSpeed = 2f;

    int index = 0;

    void Start()
    {
        wayPoints = waveConfig.getPath();
        transform.position = wayPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if (index <= wayPoints.Count - 1)
        {
            var targetPos = wayPoints[index].transform.position;
            var speed = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);

            if (transform.position == targetPos)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
