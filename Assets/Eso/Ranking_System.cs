using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_System : MonoBehaviour
{
    public float current_score;
    public List<float> Ranking;
    [SerializeField] public Text Ran1;
    [SerializeField] public Text Ran2;
    [SerializeField] public Text Ran3;
    [SerializeField] public Text Ran4;
    [SerializeField] public Text Ran5;
    void Start()
    {
        current_score = 10;
        Ranking.Add(current_score);

        Ranking.Sort();
        Ranking.Reverse();
        foreach (var aiueo in Ranking)
        {
            Debug.Log(aiueo.ToString());
        }
    }
        
    void Update()
    {

    }
}
