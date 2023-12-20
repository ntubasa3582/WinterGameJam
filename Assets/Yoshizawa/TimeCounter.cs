using UnityEngine;
using UnityEngine.UI;

// 日本語対応
public class TimeCounter : MonoBehaviour
{
    public static TimeCounter Instance => _instance;
    public int RemainingTime => (int)_timeLimit;
    public bool IsCountDown { get; set; } = true;

    [SerializeField] private float _timeLimit = 10;

    private static TimeCounter _instance = null;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (IsCountDown)
        {
            _timeLimit = Mathf.Clamp(_timeLimit - Time.deltaTime, 0, _timeLimit);
        }
    }
}
