using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCon : MonoBehaviour
{
    public GameObject target;
    void meditation(int value)
    {
        if(value == 1002)
        {
            target.SendMessage("create");
        }
    }
}
