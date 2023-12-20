using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject _upperPanel;
    [SerializeField] GameObject _lowerPanel;
    SpriteRenderer _upperRenderer;
    SpriteRenderer _lowerRenderer;
    float _timer;
    int _clickCount = 0;

    private void Start()
    {
        _upperRenderer = _upperPanel.GetComponent<SpriteRenderer>();
        _lowerRenderer = _lowerPanel.GetComponent<SpriteRenderer>();
        _upperRenderer.color = new Color(0, 0, 0, 0);
        _lowerRenderer.color = new Color(0, 0, 0, 255);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickCount++;
            _timer += Time.deltaTime;
        }
        _timer = 0;
    }
    void FirstStep()
    {
        _upperRenderer.color = new Color(0, 0, 0, 64);
        _lowerRenderer.color = new Color(0, 0, 0, 128);
    }
    void SecondStep()
    {

    }
}
