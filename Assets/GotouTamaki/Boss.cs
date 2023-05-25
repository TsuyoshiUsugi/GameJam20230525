using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    Vector3 _dir = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        InsideCamera();

        if (_isInsideCamera)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += _dir * _horiSpeed;

        if(transform.position.x > Camera.main.ViewportToWorldPoint(Vector2.one).x) 
        {
            _dir *= -1;
        }
        else if(transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x)
        {
            _dir *= -1;
        }
    }
}
