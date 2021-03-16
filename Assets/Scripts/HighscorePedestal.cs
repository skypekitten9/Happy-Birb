using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscorePedestal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore") == false)
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }
        if(PlayerPrefs.GetInt("Highscore") <= 0)
        {
            gameObject.GetComponentInChildren<TextMeshPro>().text = "";
        }
        else 
        {
            gameObject.GetComponentInChildren<TextMeshPro>().text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        
    }
}
