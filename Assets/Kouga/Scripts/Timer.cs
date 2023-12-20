using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _timerText;

    private void Update()
    {
        _timerText.text = "TIME : " + TimeCounter.Instance.RemainingTime.ToString();
    }
}
