using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValue : MonoBehaviour
{
    Ranking_System2 system;
    private void Awake()
    {
        system = GetComponent<Ranking_System2>();
    }
    public void RanodmNum()
    {
        int num = Random.Range(0, 1000);
        system.RankingUpdata(num);
    }
}
