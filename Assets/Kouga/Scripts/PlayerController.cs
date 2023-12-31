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
    [SerializeField] GameObject _effect;
    Rigidbody2D _rb = default;
    bool _isGrounded = false;
    bool _isDamaged = false;
    Animator _anim = default;
    SpriteRenderer _sprite = default;
    float _h;
    [SerializeField] float _damageTimer = 0;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip _JumpSE;
    [SerializeField] AudioClip _DamageSE;

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
            audioSource.PlayOneShot(_JumpSE);
            _isGrounded = false;
            velocity.y = _jumpPower;
            GameObject _jumpEffect = Instantiate(_effect);
            _jumpEffect.transform.position = this.transform.position;
            //_JumpSE.Play();
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            // 上昇中にジャンプボタンを離したら上昇を減速する
            velocity.y *= _gravityDrag;
        }
        if(_isDamaged)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer > 5)
            {
                
                _isDamaged = false;
                _damageTimer = 0;
            }
            else if(_damageTimer > 1)
            {
                _moveSpeed = 20.0f;
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
            audioSource.PlayOneShot(_DamageSE);
            _isDamaged = true;
            _moveSpeed = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            _rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
        if(collision.gameObject.tag == "Gimmick" && !_isDamaged)
        {
            audioSource.PlayOneShot(_DamageSE);
            _isDamaged = true;
            _moveSpeed = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Ground")
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
            _anim.SetBool("IsGrounded", _isGrounded);
            _anim.SetBool("Damaged", _isDamaged);
        }
    }
}
