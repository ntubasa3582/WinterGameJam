using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_System2 : MonoBehaviour
{
    public float current_score;
    List<float> _rankingNum = new List<float>();
    [SerializeField] Text[] _rankingText;
    private void Awake()
    {
    }
    public void RankingUpdata(float num)
    {
        float value = num;
        _rankingNum.Add(value);
        if (_rankingNum.Count != 1)
        {
            _rankingNum.Sort();
            _rankingNum.Reverse();
        }
        if (_rankingNum.Count < 5)
        {
            for (int i = 0; i < _rankingNum.Count; i++)
            {
                _rankingText[i].text = _rankingNum[i].ToString("0000");
            }
        }
        else
        {
            _rankingNum.Sort();
            _rankingNum.Reverse();
            for (int i = 0; i < _rankingText.Length; i++)
            {
                _rankingText[i].text = _rankingNum[i].ToString("0000");
            }
        }

        num = 0;
    }
}
