using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
     float m_speed = 10f;
    float m_lifeTime = 5f;
    void Start()
    {
        // 右方向に飛ばす
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * m_speed;
        // 生存期間が経過したら自分自身を破棄する
        Destroy(gameObject, m_lifeTime);
    }
}
