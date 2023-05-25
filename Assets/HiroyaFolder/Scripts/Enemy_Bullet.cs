using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    float _speed = 10f;
    float _lifeTime = 5f;
    Vector2 _target_Vec;
    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up* _speed;
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
