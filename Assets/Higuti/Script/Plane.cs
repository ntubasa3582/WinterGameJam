using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Plane : MonoBehaviour
{
    public float spownTime = 1;
    [SerializeField] GameObject _block;
    float num = 1;
    bool spown = false;
    void Start()
    {
        _block.SetActive(false);
        StartCoroutine(Call());
    }

    void Update()
    {

    }
    IEnumerator Call()
    {
        yield return new WaitForSeconds(spownTime);
        spown = true;
    }
    private void FixedUpdate()
    {
        if (spown)
        {
            num += 0.02f;
            if (_block.activeInHierarchy && num >= 3)
            {
                _block.SetActive(false);
                num = 0;
            }
            if (!_block.activeInHierarchy && num >= 3)
            {
                _block.SetActive(true);
                num = 0;
            }
        }
    }
}
