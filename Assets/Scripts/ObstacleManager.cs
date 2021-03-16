using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector2 limitsOffsetY;
    public float stepSize;
    public int amountSoftLimit;
    Transform playerTransform;
    int score;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.position -= new Vector3(-3 * (stepSize * (amountSoftLimit / 2)), 0, 0);
        obstacle.GetComponent<Obstacle>().maxDistance = stepSize * amountSoftLimit;
        for (int i = 0; i < (amountSoftLimit/2); i++)
        {
            PlaceObstacle();
            Step();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.GameOver) return;
        if (playerTransform.position.x > transform.position.x)
        {
            PlaceObstacle();
            Step();
        }
    }

    private void PlaceObstacle()
    {
        score++;
        obstacle.GetComponent<Obstacle>().DisplayScore(score);
        obstacle.transform.position = new Vector3(transform.position.x + (stepSize * (amountSoftLimit/2)), transform.position.y + Random.Range(limitsOffsetY.x, limitsOffsetY.y), transform.position.z);
        Instantiate(obstacle);
    }

    private void Step()
    {
        transform.position += new Vector3(stepSize, 0, 0);
    }


}
