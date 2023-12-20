using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] int _myScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
             _scoreManager.AddScore(_myScore);
        }
        //if (collision.gameObject.tag == "Player" && this.gameObject.tag == "BigCoin")
        //{
        //    Destroy(this.gameObject);
        //    _scoreManager.AddScore_BigCoin();
        //}
    }
}
