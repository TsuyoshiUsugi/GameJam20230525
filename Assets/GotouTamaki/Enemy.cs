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
    float _speed = 1f;
    [SerializeField]
    GameObject _bullet = default;

    bool _isInsideCamera = false;

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
            Move();
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

    void Move()
    {
        this.transform.position = new Vector3(0,_dir * _speed,0);
    }

    void OnBecameInvisible()
    {
        _isInsideCamera = false;
    }

    void OnBecameVisible()
    {
        _isInsideCamera = true;
    }
}

