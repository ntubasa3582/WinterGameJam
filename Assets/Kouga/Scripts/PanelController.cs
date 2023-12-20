using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject _upperPanel;
    [SerializeField] GameObject _lowerPanel;
    [SerializeField] float _timer;
    [SerializeField] int _clickCount = 0;

    private void Start()
    {
        _upperPanel.SetActive(false);
        _lowerPanel.SetActive(true);
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("leftclick");
            _clickCount++;
            _timer = 0;
            if(_clickCount >= 7 && _timer <= 2)
            {
                _upperPanel.SetActive(true);
                _lowerPanel.SetActive(false);
                _timer = 0;
            }
        }
        else if(_clickCount <= 7 && _timer >= 2)
        {
            _clickCount = 0;
            _upperPanel.SetActive(false);
            _lowerPanel.SetActive(true);
        }
        if (_timer >= 2)
        {
            _clickCount = 0;
        }
    }
}
