using UnityEngine;

// 日本語対応
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => _instance;
    public float BgmVolume { get => _bgm.volume; set => _bgm.volume = Mathf.Clamp01(value); }
    public float SeVolume { get => _se.volume; set => _se.volume = Mathf.Clamp01(value); }

    [SerializeField] private AudioSource _bgm = null;
    [SerializeField] private AudioSource _se = null;
    [SerializeField] private AudioClip[] _soundClips = null;

    private static AudioManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _bgm ??= gameObject.AddComponent<AudioSource>();
        _bgm.playOnAwake = true;
        _bgm.loop = true;

        _se ??= gameObject.AddComponent<AudioSource>();
        _se.playOnAwake = false;
        _se.loop = false;
    }

    public void PlayBGM(PlayClips clipNumber)
    {
        if ((int)clipNumber >= _soundClips.Length) return;
        _bgm.clip = _soundClips[(int)clipNumber];
        _bgm.Play();
    }
    public void PlaySE(PlayClips clipNumber)
    {
        if ((int)clipNumber >= _soundClips.Length) return;
        _se.PlayOneShot(_soundClips[(int)clipNumber]);
    }
    public void StopBGM() => _bgm.Stop();
    public void StopSE() => _se.Stop();
}

public enum PlayClips
{
    TitleBGM,
    InGameBGM,
    GameStartSE,
    GameClearSE,
    GameOverSE,
    MomDashSE,
    MomKnockSE,
    MomDoorOpenSE,
    PhaseDreamSE,
    JumpSE,
    DamageSE,
    EnemyDeathSE,
    CoinSE,
    LessTimeSE,
}
