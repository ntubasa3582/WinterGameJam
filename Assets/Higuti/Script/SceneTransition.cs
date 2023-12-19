using UnityEngine;
using UnityEngine.SceneManagement;

// 日本語対応
public class SceneTransition : MonoBehaviour
{
    public void Transition(string next)
    {
        SceneManager.LoadScene(next);
    }
}
