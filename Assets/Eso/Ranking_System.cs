using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_System : MonoBehaviour
{
    public List<float> values;
    [SerializeField] public Text Ran1;
    [SerializeField] public Text Ran2;
    [SerializeField] public Text Ran3;
    [SerializeField] public Text Ran4;
    [SerializeField] public Text Ran5;
    void Start()
    {
        foreach (var values in values)
        {
            Debug.Log(values.ToString());
        }
    }
        
    void Update()
    {
        
    }
}
