using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    float _lifeTime;
    SpriteRenderer _playerSprite;
    SpriteRenderer _renderer;
    private void Start()
    {
        GameObject _player = GameObject.Find("Player");
        _playerSprite = _player.GetComponent<SpriteRenderer>();
        _renderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _lifeTime += Time.deltaTime;
        if( _lifeTime > 0.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        if (_playerSprite.flipX)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }
    }
}
