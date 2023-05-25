using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
     float m_speed = 10f;
    float m_lifeTime = 5f;
    void Start()
    {
        // �E�����ɔ�΂�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * m_speed;
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(gameObject, m_lifeTime);
    }
}
