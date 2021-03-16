using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameColor : MonoBehaviour
{
    public Color color;
    bool changed;
    void Update()
    {
        if (GameManager.Instance.GameOver && changed == false)
        {
            gameObject.GetComponent<Renderer>().material.color = color;
            changed = true;
        }
    }
}
