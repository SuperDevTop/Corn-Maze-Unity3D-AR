using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int RandSelect(List<int> elements)
    {
        int index = Random.RandomRange(0, elements.Count);

        return elements[index];
    }
}
