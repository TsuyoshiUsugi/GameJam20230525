using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    enum EnemyType{
        Enemy,
        Boss,
    }

    [SerializeField]
    GameObject _enemy_Bullet;
    [SerializeField]
    GameObject _enemy_HomingBullet;
    [SerializeField]
    GameObject _repair_Item;
    [SerializeField]
    GameObject _score_Item;
    [SerializeField]
    int _enemyMAXHP = 100;
    [SerializeField]
    EnemyType _enemyType;
    [SerializeField]
    int _scoreItemCount = 3;
    [SerializeField]
    int _repairItemCount = 3;
    [SerializeField]
    GameObject _bossHPUI;
    Image _bossHPImage = null;
    Boss _boss = null;
    int _enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        _bossHPImage = _bossHPUI.GetComponent<Image>();
        _enemyHP = _enemyMAXHP;

            
    }
    float _bullet_Time = 0f;

    void Update()
    {
        if (_enemyType == EnemyType.Boss)
        {
            _boss = GetComponent<Boss>();
            if (_boss.InsideCamera())
            {
                _bossHPUI.SetActive(true);
            }

        }
        if (_enemyHP <= 0)
        {
           DropItems(_score_Item, _scoreItemCount);
           DropItems  (_repair_Item, _repairItemCount);
           Destroy(gameObject);
        }

        _bullet_Time += Time.deltaTime;
        if(_enemyType == EnemyType.Boss)
        {
            _bossHPImage.fillAmount = (float)_enemyHP / (float)_enemyMAXHP;
            if (_bullet_Time > 3f)
            {
                _bullet_Time = 0f;
                BossShot(_enemy_Bullet);
            }
        }
        if(_enemyType == EnemyType.Enemy)
        {
            if (_bullet_Time > 0.5f)
            {
                _bullet_Time = 0f;
                Instantiate(_enemy_HomingBullet, transform.position + new Vector3(0, -1f, 0), Quaternion.identity);
            }
        }

    }

    public void BossShot(GameObject gameObject)
    {
        for (float i = 0; i < 360; i += 6f)
        {
            Instantiate(gameObject, transform.position, Quaternion.identity * Quaternion.AxisAngle(new Vector3(0, 0, 1), i));
        }
    }
    public void DropItems(GameObject gameObject,int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(gameObject, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) , Quaternion.identity);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            DamagetoEnemy(15);
            Destroy(other.gameObject);
        }
    }
    public void DamagetoEnemy(int damege)
    {
        _enemyHP -= damege;
    }
}
