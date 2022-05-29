using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    public  Image HealthBarImage;
    public static HealthBarHandler Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        

    }
    public void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public  float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public  void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }
}
