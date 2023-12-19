using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    [SerializeField] AudioSource _as;
    [SerializeField] Image fadeImage;
    float fadeDuration = 1.0f;
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fadeout());
        }
    }
    IEnumerator Fadeout()
    {
        //_as.Play();
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            Debug.Log("フェードアウト中");
            yield return null;
        }
        //SceneManager.LoadScene("");
        fadeImage.enabled = false;
    }
}
