using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuStone3Scrpit : MonoBehaviour
{
    public GameObject Wall3;
    int a = 0;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            a = +1;
        }
    }
    void attention(int value)
    {
        if (value == 1002 && a == 1)
        {
            Wall3.SetActive(false);
        }
    }
}
