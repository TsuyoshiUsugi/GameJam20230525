using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Manager : MonoBehaviour
{
    float _speed = 10f;
    float _lifeTime = 3f;
    void Start()
    {
        // �E�����ɔ�΂�
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.up * _speed;
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(gameObject, _lifeTime);
    }
}
