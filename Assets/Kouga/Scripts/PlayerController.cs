using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1.0f;
    [SerializeField] float _jumpPower = 3.0f;
    [SerializeField] float _dashSpeed = 2.0f;
    [SerializeField] float _gravityDrag = .99f;
    Rigidbody2D _rb = default;
    bool _isGrounded = false;
    bool _isDamaged = false;
    Animator _anim = default;
    SpriteRenderer _sprite = default;
    float _h;
    [SerializeField] float _damageTimer = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            velocity.y = _jumpPower;
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            // 上昇中にジャンプボタンを離したら上昇を減速する
            velocity.y *= _gravityDrag;
        }
        if(_isDamaged)
        {
            _damageTimer += Time.deltaTime;
            if(_damageTimer > 5)
            {
                _isDamaged = false;
                _damageTimer = 0;
            }
        }

        _rb.velocity = velocity;
    }

    void FixedUpdate()
    {
        if (!Input.GetButton("Fire3"))
        {
            _rb.AddForce(Vector2.right * _h * _moveSpeed);
        }
        else
        {
            _rb.AddForce(Vector2.right * _h * _moveSpeed * _dashSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !_isDamaged)
        {
            _isDamaged = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
    private void LateUpdate()
    {
        // キャラクターの左右の向きを制御する
        if (_h != 0)
        {
            _sprite.flipX = (_h < 0);
        }

        // アニメーションを制御する
        if (_anim)
        {
            _anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
            _anim.SetBool("Damaged", _isDamaged);
        }
    }
}
