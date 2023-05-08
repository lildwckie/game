using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    public float speed;
    public Transform bg1;
    public Transform bg2;
    float m_ySize;
    public bool isStart;

    private void Awake()
    {
        m_ySize = bg1.GetComponent<BoxCollider2D>().size.y * bg1.transform.localScale.y;

        bg1.position = Vector3.zero;

        bg2.position = new Vector3(
            bg1.position.x,
            bg1.position.y + m_ySize,
            0f
            );
    }
    private void Update()
    {
        if (!isStart) return;

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(bg1.position.y <= -m_ySize)
        {
            bg1.position = new Vector3(
                bg2.transform.position.x,
                bg2.transform.position.y + m_ySize,
                0f
                );

            Transform temp = bg1;

            bg1 = bg2;
            bg2 = temp;

            GameManager.Ins.Score++;
            GameGUIManager.Ins.UpdateScore(GameManager.Ins.Score);
        }
    }
}
