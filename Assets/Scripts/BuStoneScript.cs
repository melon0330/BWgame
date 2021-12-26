using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuStoneScript : MonoBehaviour
{
    public GameObject Wall1;
    bool a = false;
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            a = true;
        }
    }
    void open()
    {
        if (a)
        {
            Wall1.SetActive(false);
        }
    }

}
