using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    float offSet;

    private void Start()
    {
        offSet = transform.position.x;
    }

    private void Update()
    {
        if (GameManager.Instance.GameOver == false)
        {
            transform.position = new Vector3(target.transform.position.x + offSet, transform.position.y, transform.position.z);
        }
    }
}
