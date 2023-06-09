using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Manager : MonoBehaviour
{
    float _speed = 10f;
    float _lifeTime = 1.5f;
    void Start()
    {
        // 右方向に飛ばす
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;
        // 生存期間が経過したら自分自身を破棄する
        Destroy(gameObject, _lifeTime);
    }
}
