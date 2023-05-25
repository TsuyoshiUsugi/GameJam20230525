using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int _hp = 10;
    [SerializeField]
    float _dir = -1f;
    [SerializeField]
    float _vertSpeed = 1f;
    [SerializeField]
    float _horiSpeed = 1f;
    [SerializeField]
    GameObject _bullet = default;
    [SerializeField]
    MoveType _moveType;

    bool _isInsideCamera = true;
    float _x = 0;

    enum MoveType 
    {
        VerticalMove,
        HorizontalMove,
        SinCurveMove,
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInsideCamera)
        {
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
                SinCurveMove(Time.time);
            }
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(_bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }

    public void Hit(int damege)
    {
        _hp -= damege;

        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void VerticalMove()
    {
        this.transform.position += new Vector3(transform.position.x,_dir * _vertSpeed, 0);
    }

    void HorizontalMove() 
    {
        this.transform.position += new Vector3(_dir * _horiSpeed, 0, 0);
    }

    void SinCurveMove(float time) 
    {
        _x = Mathf.Sin(time);
        Debug.Log(_x);
        this.transform.position = new Vector3(_x * _horiSpeed, transform.position.y,0);
        VerticalMove();
    }

    void OnBecameInvisible()
    {
        _isInsideCamera = false;
        Debug.Log("Œ©‚¦‚Ä‚¢‚È‚¢");
    }

    void OnBecameVisible()
    {
        _isInsideCamera = true;
        Debug.Log("Œ©‚¦‚Ä‚é");
    }
}

