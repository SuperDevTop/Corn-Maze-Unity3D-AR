using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SplashScene : MonoBehaviour
{
    public static DateTime registeredTime;
    public static string gameplayLang = "french";

    void Start()
    {
        registeredTime = DateTime.Now;
    }

    public void TouchScreenClick()
    {
        Application.LoadLevel("Home");
    }
}
