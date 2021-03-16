﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform playerTransform;
    public float maxDistance;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (GameManager.Instance.GameOver) return;
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
