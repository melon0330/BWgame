using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2gCon : MonoBehaviour
{
    public GameObject target;
    void attention(int value)
    {
        if (value == 1000)
        {
            target.SendMessage("open");
        }
    }
}
