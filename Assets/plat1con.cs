using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat1con : MonoBehaviour
{
    void move()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(13, 0, 0), 0.6f);
    }

    void back()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0, 0, 0), 0.6f);
    }

}
