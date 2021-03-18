using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{
    public KeyCode keycode;
    public string name;
    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            Debug.Log("Screen captured!");
            ScreenCapture.CaptureScreenshot(name, quality);
        }
    }
}
