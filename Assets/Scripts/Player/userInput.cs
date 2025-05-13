using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class userInput : MonoBehaviour
{
    public static userInput instance;

    [HideInInspector] public Controls controls;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
