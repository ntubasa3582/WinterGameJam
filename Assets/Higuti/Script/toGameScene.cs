using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toGameScene : MonoBehaviour
{
    Button _bt;
    [SerializeField] Image fadeImage;
    public float fadeDuration = 1.0f;
    void Start()
    {
        _bt = GetComponent<Button>();
        _bt.onClick.AddListener(call);
    }
    void call()
    {
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("Config");
        fadeImage.enabled = false;
    }
    void Update()
    {

    }
}
