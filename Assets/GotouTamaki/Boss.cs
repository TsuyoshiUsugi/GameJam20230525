using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    Vector3 _hDir = Vector3.right;
    Vector3 _vDir = Vector3.down;
    float _currentTime = 0;

    [SerializeField]
    float _decreaseSpeedNum = 1f;
    EnemyManager _enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentTime += Time.deltaTime;
        //ChangeHoriSpeed();
    }

    protected override void FixedUpdate()
    {
        if (InsideCamera())
        {
            _enemyManager.enabled = true;
            HoriMove();
            VertMove();
        }
        else
        {
            _enemyManager.enabled = false;
        }
    }

    void HoriMove()
    {
        transform.position += _hDir * _horiSpeed;

        if (transform.position.x > Camera.main.ViewportToWorldPoint(Vector2.one).x - 1f)
        {
            _hDir *= -1;
        }
        else if (transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x + 1f)
        {
            _hDir *= -1;
        }
    }

    void VertMove()
    {
        transform.position += _vDir * _vertSpeed;

        if (transform.position.y > Camera.main.ViewportToWorldPoint(Vector2.one).y - 1f)
        {
            _vDir *= -1;
        }
        else if (transform.position.y < Camera.main.ViewportToWorldPoint(Vector2.zero).y + 1f)
        {
            _vDir *= -1;
        }
    }

    void ChangeHoriSpeed()
    {
        _horiSpeed -= _decreaseSpeedNum * _currentTime;
    }
}
