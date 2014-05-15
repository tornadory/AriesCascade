﻿using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

    private bool isPaused;
    public GUISkin skin;
    public GameObject payload;
    public static Vector3 velVec;
    private float velNum;

	// Use this for initialization
	void Start () {
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape") && !isPaused)
        {
            print("Paused");
            Time.timeScale = 0.0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            isPaused = false;
        }
	}

    void OnGUI()
    {
        GUI.skin = skin;

        if(isPaused)
        {
            if (GUI.Button(new Rect(Screen.width - 120, 10, 100, 50), "Resume"))
            {
                isPaused = false;
            }
        }
        else
        {
            if(GUI.Button(new Rect(Screen.width - 120, 10, 100, 50), "Pause"))
            {
                isPaused = true;
            }
        }

        velVec = (payload.GetComponent<Rigidbody>().velocity) * -1.0f;
        velVec.Normalize();

        GUI.Label(new Rect(10, 10, 1000, 2000), "Velocity: " + velVec.ToString("##0.00"));
    }
}
