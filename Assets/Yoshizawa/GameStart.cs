using UnityEngine;
using UnityEngine.Events;

// 日本語対応
public class GameStart : MonoBehaviour
{
    [SerializeField] private UnityEvent _gameStartEvent = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) _gameStartEvent?.Invoke();
    }
}
