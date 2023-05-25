using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField]
    //protected int _hp = 10;
    [SerializeField]
    float _dir = -1f;
    [SerializeField]
    protected float _vertSpeed = 1f;
    [SerializeField]
    protected float _horiSpeed = 1f;
    //[SerializeField]
    //protected GameObject _bullet = default;
    [SerializeField]
    MoveType _moveType;

    protected bool _isInsideCamera = false;
    float _x = 0;
    float _startTime = 0;
    float _originalX = 0;

    EnemyManager _enemyManager;
    enum MoveType 
    {
        VerticalMove,
        HorizontalMove,
        SinCurveMove,
    }

    // Start is called before the first frame update
    void Start()
    {
        _originalX = transform.position.x;
        _enemyManager = GetComponent<EnemyManager>();
        //StartCoroutine(Shoot());
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {      
        if (InsideCamera())
        {
            _enemyManager.enabled = true;
            _startTime += Time.deltaTime;

            if(_moveType == MoveType.VerticalMove)
            {
                VerticalMove();
            }
            else if (_moveType == MoveType.HorizontalMove)
            {
                HorizontalMove();
            }
            else if (_moveType == MoveType.SinCurveMove)
            {
                SinCurveMove();
            }
        }
        else
        {
            _enemyManager.enabled = false;
        }
    }

    //IEnumerator Shoot()
    //{
    //    Instantiate(_bullet, this.transform.position, Quaternion.identity);
    //    yield return new WaitForSeconds(1);
    //    StartCoroutine(Shoot());
    //}

    //public void Hit(int damege)
    //{
    //    _hp -= damege;

    //    if (_hp <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    void VerticalMove()
    {
        this.transform.position += new Vector3(0,_dir * _vertSpeed, 0);
    }

    void HorizontalMove() 
    {
        this.transform.position += new Vector3(_dir * _horiSpeed, 0, 0);
    }

    void SinCurveMove() 
    {
        _x = Mathf.Sin(_startTime * _horiSpeed) + _originalX;
        Debug.Log(_x);
        transform.position = new Vector3(_x ,transform.position.y, 0);
        VerticalMove();
    }

    public bool InsideCamera()
    {
        float y = Camera.main.ViewportToWorldPoint(Vector2.one).y;
        if (y > transform.position.y && transform.position.y > Camera.main.ViewportToWorldPoint(Vector2.zero).y) 
        {
            return true;
        }
        return false;

    }
}

