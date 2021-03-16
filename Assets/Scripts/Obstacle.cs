using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform playerTransform;
    public float maxDistance;
    bool hasScored;

    void Start()
    {
        playerTransform = Bird.Instance.transform;
    }


    void Update()
    {
        if (GameManager.Instance.GameOver) return;
        if (transform.position.x < playerTransform.position.x && hasScored == false)
        {
            GameManager.Instance.IncreaseScore();
            hasScored = true;
        }
        if (Vector3.Distance(transform.position, playerTransform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    public void DisplayScore(int x)
    {
        gameObject.GetComponentInChildren<TextMeshPro>().text = x.ToString();
    }
}
