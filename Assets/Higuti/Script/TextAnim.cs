using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnim : MonoBehaviour
{
    Animation _anim;
    void Start()
    {
        _anim = GetComponent<Animation>();
    }
    void AnimPlay()
    {
        Debug.Log("テキストアニメーション再生中");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
