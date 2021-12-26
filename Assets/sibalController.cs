using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sibalController : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void attention(int value)
    {
        if(value == 1000)
        {
            target.SendMessage("move");
        }
    }
    void meditation(int value)
    {
        if(value == 1002)
        {
            target.SendMessage("back");
        }
    }
}
