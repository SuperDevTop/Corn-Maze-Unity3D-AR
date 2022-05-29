using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{    
    DateTime startTime;
    int minutes;
    int seconds;
      
    void Start()
    {
        startTime = DateTime.Now;       
        
    }
   
    void Update()
    {
        int passedTime = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) - (startTime.Hour * 3600 + startTime.Minute * 60 + startTime.Second);
        minutes = passedTime / 60;
        seconds = passedTime % 60;

        if (minutes > 34 && seconds > 50)
        {
            this.GetComponent<Text>().text = "0" + (44 - minutes) + ":0" + (60 - seconds);
        } 
        else if (minutes > 34 && seconds <= 50)
        {
            this.GetComponent<Text>().text = "0" + (44 - minutes) + ":" + (60 - seconds);
        }
        else if (minutes <= 34 && seconds > 50)
        {
            this.GetComponent<Text>().text = "" + (44 - minutes) + ":0" + (60 - seconds);
        }
        else if (minutes <= 34 && seconds <= 50)
        {
            this.GetComponent<Text>().text = "" + (44 - minutes) + ":" + (60 - seconds);
        }
    }
}
