using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toGameScene : MonoBehaviour
{
    [SerializeField] AudioSource _pushSound;
    [SerializeField] Image fadeImage;
    public float fadeDuration = 1.0f;
    void Start()
    {
        
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
        _pushSound.Play();
        SceneManager.LoadScene("");
        fadeImage.enabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
