using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed;

    Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(m_rb) {
            m_rb.velocity = Vector2.down * speed;
        }
    }
}
