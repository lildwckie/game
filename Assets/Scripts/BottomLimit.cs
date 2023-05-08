using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    //Huy xe khi ra khoi man hinh
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Const.OBSTACLE_TAG))
        {
            Destroy(col.gameObject);
        }
    }
}
