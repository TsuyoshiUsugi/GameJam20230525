using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
     float m_speed = 10f;
    float m_lifeTime = 5f;
    void Start()
    {
        // ‰E•ûŒü‚É”ò‚Î‚·
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * m_speed;
        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        Destroy(gameObject, m_lifeTime);
    }
}
