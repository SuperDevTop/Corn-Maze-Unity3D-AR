using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (this.tag == "C_Crown")
        {
            GameEngine.Instance.isCCrownClick = true;
        }
        else if (this.tag == "S_Crown")
        {
            print(12312312312312312);
            GameEngine.Instance.isSCrownClick = true;
        }
        else if (this.tag == "P_Crown")
        {
            GameEngine.Instance.isPCrownClick = true;
        }
    }
}
