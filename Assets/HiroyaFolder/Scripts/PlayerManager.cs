using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    //[SerializeField]
    //GameObject _camera;
    [SerializeField]
    GameObject _player_Bullet = default;
    [SerializeField]
    Text _playerHP_Text = default;
    [SerializeField]
    Text _timeText = default;
    [SerializeField]
    Text _scoreText = default;
    [SerializeField]
    AudioSource _audioSource = null;
    [SerializeField]
    AudioClip _audioClip = null;
    private float _moveSpeed = 8f;
    private int _playerHP = 100;

    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    float _bullet_Time = 0f;
    float _elaptime = 0f;
    void Update()
    {
        //UI�\��
        _elaptime += Time.deltaTime;
        _timeText.text = $"{((int)_elaptime / 60).ToString("00")}:{((_elaptime % 60).ToString("00.00"))}";
        _scoreText.text = $"Score: {SCORE_MANAGER.Score.ToString()}";
        _playerHP_Text.text = $"HP: {_playerHP}";
        //�ړ�����
        Vector2 _position_Limit = Camera.main.ViewportToWorldPoint(Vector2.one);
        _position_Limit -= new Vector2(0.5f, 0.5f);
        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -_position_Limit.x, _position_Limit.x);
        currentPos.y = Mathf.Clamp(currentPos.y, -_position_Limit.y, _position_Limit.y);
        transform.position = currentPos;

        
        if (_playerHP <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
        //�e�̔��ˊԊu
        _bullet_Time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _bullet_Time > 0.2f)
        {
            _audioSource.PlayOneShot(_audioClip);
            _bullet_Time = 0f;
            Instantiate(_player_Bullet, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
        //transform.position = _camera.transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            _rb2D.velocity =new Vector2(-_moveSpeed,_rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb2D.velocity = new Vector2(_moveSpeed, _rb2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            _rb2D.velocity = new Vector2( _rb2D.velocity.x, _moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, -_moveSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            SCORE_MANAGER.AddScore(10);
        }
        if (other.gameObject.tag == "RepairItem")
        {
            DamagetoPlayer(-5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ScoreItem")
        {
            SCORE_MANAGER.AddScore(100);
            Destroy(other.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            DamagetoPlayer(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            DamagetoPlayer(50);
        }
    }

    public void DamagetoPlayer(int damege)
    {
        _playerHP -= damege;
        if( _playerHP > 100)
        {
            _playerHP = 100;
        }
    }
}
