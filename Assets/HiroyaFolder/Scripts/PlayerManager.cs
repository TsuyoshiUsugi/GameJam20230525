using System.Collections;
using System.Collections.Generic;
using Unity.Rendering.HybridV2;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    //[SerializeField]
    //GameObject _camera;
    [SerializeField]
    GameObject _player_Bullet = default;
    [SerializeField]
    Text _playerHP_Text = default;
    private float _horizonal_MoveSpeed = 10f;

    private int _playerHP = 100;

    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    float _bullet_Time = 0f;
    void Update()
    {
        _playerHP_Text.text = $"PlayerHP: {_playerHP}";
        if (_playerHP <= 0)
        {
            Destroy(gameObject);
        }

        _bullet_Time += Time.deltaTime;
        if (Input.GetKey(KeyCode.B) && _bullet_Time > 0.1f)
        {
            _bullet_Time = 0f;
            Instantiate(_player_Bullet, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
        //transform.position = _camera.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            _rb2D.AddForce(Vector2.up * _horizonal_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb2D.AddForce(Vector2.down * _horizonal_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb2D.AddForce(Vector2.left * _horizonal_MoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb2D.AddForce(Vector2.right * _horizonal_MoveSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBullet")
        {
            DamagetoPlayer(10);
            Destroy(other.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DamagetoPlayer(50);
        }
    }

    public void DamagetoPlayer(int damege)
    {
        _playerHP -= damege;
    }
}
