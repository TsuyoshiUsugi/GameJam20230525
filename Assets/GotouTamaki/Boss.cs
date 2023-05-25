using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    Vector3 _hDir = Vector3.right;
    Vector3 _vDir = Vector3.up;
    float _currentTime = 0;

    [SerializeField]
    float _decreaseSpeedNum = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        _currentTime += Time.deltaTime;
        //ChangeHoriSpeed();
    }

    protected override void FixedUpdate()
    {
        InsideCamera();

        if (_isInsideCamera)
        {
            HoriMove();
            VertMove();
        }
    }

    void HoriMove()
    {
        transform.position += _hDir * _horiSpeed;

        if(transform.position.x > Camera.main.ViewportToWorldPoint(Vector2.one).x) 
        {
            _hDir *= -1;
        }
        else if(transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x)
        {
            _hDir *= -1;
        }
    }

    void VertMove()
    {
        transform.position += _vDir * _vertSpeed;

        if (transform.position.y > Camera.main.ViewportToWorldPoint(Vector2.one).y)
        {
            _vDir *= -1;
        }
        else if (transform.position.y < Camera.main.ViewportToWorldPoint(Vector2.zero).y)
        {
            _vDir *= -1;
        }
    }

    void ChangeHoriSpeed()
    {
        _horiSpeed -= _decreaseSpeedNum * _currentTime;
    }
}
