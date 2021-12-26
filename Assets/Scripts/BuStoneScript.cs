using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuStoneScript : MonoBehaviour
{
    public GameObject Wall1;
    int a = 0;
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            a = +1;
        }
    }
    void attention(int value)
    {
        if (value == 1002 && a == 1)
        {
            Wall1.SetActive(false);
        }
    }

}
