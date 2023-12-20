using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text _scoreText;
    public static int _addScore;

    public void Start()
    {
        _scoreText.text = "SCORE : " + _addScore.ToString();
    }
    //public void AddScore_MiniCoin()
    //{
    //    _addScore += 100;
    //    _scoreText.text = "SCORE : " + _addScore.ToString();
    //}
    //public void AddScore_BigCoin() 
    //{
    //    _addScore += 500;
    //    _scoreText.text = "SCORE : " + _addScore.ToString();
    //}
    public void ResetScore()
    {
        _addScore = 0;
    }
    public int GetScore()
    {
        return _addScore;
    }
    public void AddScore(int score)
    {
        _addScore += score;
        _scoreText.text = "SCORE : " + _addScore.ToString();
    }

}
