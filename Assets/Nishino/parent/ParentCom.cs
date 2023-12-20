using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ParentCom : MonoBehaviour
{
    /// <summary>x���ŏ��l�Ay���ő�l</summary>
    [SerializeField, Header("x���ŏ��l�Ay���ő�l")] Vector2 _motherInterval = new Vector2(0, 0);
    /// <summary>1�ꂠ��0��Ȃ�</summary>
    [SerializeField] GameObject[] _motherDoors;
    [SerializeField] GameObject _particleSystem;
    [SerializeField, Header("�p�[�e�B�N���̐������W")] Vector2 _particlePos = new Vector2(0, 0);
    [SerializeField, Header("�p�[�e�B�N������������鎞��")] float _ParticleStart = 0;
    GameObject par;
    [SerializeField] public AudioSource _audioSource;
    [SerializeField] AudioClip[] _clip1;

    float _time = 0;
    /// <summary>false�����ĂȂ�true������</summary>
    bool _iscomeMother = false;//false�����ĂȂ�true������
    /// <summary>false���Q�Ă�true���N���Ă�summary>
    bool _wakeup = false;
    bool _countStop = false;
    float _randomNum = 0;
    bool _intance = true;
    [SerializeField] float _opneInterval = 4;
    void Start()
    {
        _motherDoors[1].SetActive(false);
        _iscomeMother = false;
        NumRandom();
    }

    void Update()
    {
        if (_iscomeMother == false)
        {
            Timer();
            if (_time > _randomNum)
            {
                _intance = true;
                _time = 0;
                _iscomeMother = true;
                Debug.Log("����");
                Destroy(par);
                _audioSource.PlayOneShot(_clip1[1]);
                _motherDoors[1].SetActive(true);
                if (InGameController.Instance.IsPlayerWakeUp == false )
                {
                    InGameController.Instance.IsGameOver = true;
                    Debug.Log("�N���ĂȂ�");
                    StartCoroutine("Bgm");
                }
                else if (InGameController.Instance.IsPlayerWakeUp == true)
                {
                    Debug.Log("�N���Ă�");
                    StartCoroutine("MotherOpen");
                }
            }
        }
    }

    public void NumRandom()
    {
        _randomNum = Random.Range(_motherInterval.x, _motherInterval.y);
        Debug.Log("�C���^�[�o����" +  _randomNum);
    }

    void Timer()
    {
        _time += Time.deltaTime;
        Debug.Log(_time);
        if (_randomNum - _time <= _ParticleStart)
        {
            if (_intance == true)
            {
                _audioSource.PlayOneShot(_clip1[0]);
                Debug.Log("���邼");
                par = Instantiate(_particleSystem, _particlePos, Quaternion.identity);
                _intance = false;
            }
        }
    }

    IEnumerator MotherOpen()
    {
        yield return new WaitForSeconds(_opneInterval);
        _motherDoors[1].SetActive(false);
        _iscomeMother = false;
        Debug.Log("�R���[�`���I��");
        _randomNum = 0;
        NumRandom();
    }

    IEnumerator Bgm()
    {
        yield return new WaitForSeconds(1.5f);
        _audioSource.PlayOneShot(_clip1[2]);
    }
}
