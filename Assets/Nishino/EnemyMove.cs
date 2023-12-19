using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    GameObject _camera;
    Rigidbody2D _rb;
    bool _isMove = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (_isMove == true)
        {
            _rb.AddForce(Vector2.left * _moveSpeed);
        }
    }
    private void OnBecameVisible()
    {
        _isMove = true;
    }
}
