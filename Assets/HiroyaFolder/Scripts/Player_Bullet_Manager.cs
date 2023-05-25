using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Manager : MonoBehaviour
{
    float _speed = 10f;
    float _lifeTime = 3f;
    void Start()
    {
        // ‰E•ûŒü‚É”ò‚Î‚·
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;
        // ¶‘¶ŠúŠÔ‚ªŒo‰ß‚µ‚½‚ç©•ª©g‚ğ”jŠü‚·‚é
        Destroy(gameObject, _lifeTime);
    }
}
