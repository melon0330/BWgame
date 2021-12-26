using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform1Controller : MonoBehaviour
{
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

        if (value == 1000)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(13, 0, 0), 0.6f);
        }
    }

    void meditation(int value)
    {

    }
}
