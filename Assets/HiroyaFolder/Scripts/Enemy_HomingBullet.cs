using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HomingBullet : MonoBehaviour
{
    float _speed = 10f;
    float _lifeTime = 5f;
    Vector2 _target_Vec;
    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        Transform _player = GameObject.Find("Player").GetComponent<Transform>();
        _target_Vec = _player.position - transform.position;
        _rb.velocity = _target_Vec.normalized * _speed;
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
