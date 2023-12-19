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
    Animator _anim = default;
    SpriteRenderer _sprite = default;
    float _h;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_anim = GetComponent<Animator>();
        //_sprite = GetComponent<SpriteRenderer>();
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
            // �㏸���ɃW�����v�{�^���𗣂�����㏸����������
            velocity.y *= _gravityDrag;
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
        //// �L�����N�^�[�̍��E�̌����𐧌䂷��
        //if (_h != 0)
        //{
        //    _sprite.flipX = (_h < 0);
        //}

        //// �A�j���[�V�����𐧌䂷��
        //if (_anim)
        //{
        //    _anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
        //    _anim.SetFloat("SpeedY", _rb.velocity.y);
        //    _anim.SetBool("IsGrounded", _isGrounded);
        //}
    }
}
