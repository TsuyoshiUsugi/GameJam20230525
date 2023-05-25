using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy_Bullet;
    [SerializeField]
    float _enemyHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    float _bullet_Time = 0f;
    void Update()
    {
        if (_enemyHP <= 0)
        {
            Destroy(gameObject);
        }

        _bullet_Time += Time.deltaTime;
        if(_bullet_Time > 0.5f)
        {
            _bullet_Time = 0f;
            Instantiate(_enemy_Bullet,transform.position + new Vector3(0,-1f,0),Quaternion.identity);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            DamagetoEnemy(10);
            Destroy(other.gameObject);
        }
    }
    public void DamagetoEnemy(int damege)
    {
        _enemyHP -= damege;
    }
}
