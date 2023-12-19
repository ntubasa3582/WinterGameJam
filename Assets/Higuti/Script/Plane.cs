using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Plane : MonoBehaviour
{
    [SerializeField] GameObject _block;
    float num = 0;

    void Start()
    {
        _block.SetActive(false);
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {

        num += 0.02f;
        if (_block.activeInHierarchy && num >= 1)
        {
            _block.SetActive(false);
            num = 0;
        }
        if (!_block.activeInHierarchy && num >= 1)
        {
            _block.SetActive(true);
            num = 0;
        }
    }
}
