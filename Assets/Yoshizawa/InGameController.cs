using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// 日本語対応
public class InGameController : MonoBehaviour
{
    public static InGameController Instance => _instance;
    public event Action PauseAction { add => _pauseAction += value; remove => _pauseAction -= value; }
    public event Action ResumeAction { add => _resumeAction += value; remove => _resumeAction -= value; }
    public bool IsPause { get; private set; } = false;
    public bool IsGameClear { get; set; } = false;
    public bool IsGameOver { get; set; } = false;
    public bool IsPlayerWakeUp { get; private set; } = true;

    [SerializeField] private KeyCode _switchKey = KeyCode.None;
    [SerializeField] private Image _panel = null;
    [SerializeField] private float _switchDuration = 3.0f;
    [SerializeField] private UnityEvent _GameClearEvent = null;
    [SerializeField] private UnityEvent _GameOverEvent = null;

    private static InGameController _instance = null;
    private event Action _pauseAction = null;
    private event Action _resumeAction = null;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        SwitchPlayerWakeUp();
        GameFinish();
    }

    private void SwitchPlayerWakeUp()
    {
        if (Input.GetKeyDown(_switchKey))
        {
            ResetInterval();
            IsPlayerWakeUp = true;
            UnityEngine.Debug.Log("Wake Up");
        }

        if (IsPlayerWakeUp && IsSpendInterval(_switchDuration, Time.deltaTime))
        {
            IsPlayerWakeUp = false;
        }
    }

    private float _timer = 0.0f;
    private bool IsSpendInterval(float interval, float addTime)
    {
        _timer += addTime;

        if (_timer > interval) { _timer = 0.0f; return true; }
        return false;
    }

    private void ResetInterval() => _timer = 0.0f;

    private void GameFinish()
    {
        if (IsGameClear && !IsGameOver)
        {
            _GameClearEvent?.Invoke();
        }
        else if (!IsGameClear && IsGameOver)
        {
            _GameOverEvent?.Invoke();
        }
    }
}
