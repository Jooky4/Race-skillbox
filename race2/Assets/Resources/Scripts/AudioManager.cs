using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] audioClips;

    public static AudioManager instance;

    private AudioSource player;

    private void Awake()
    {
        player = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (instance == null) instance = this;

        DontDestroyOnLoad(gameObject); // объект не будет уничтожатся при загрузке новой сцены
    }


    public void playSound(AudioClip clip)
    {
        player.clip = clip;
        player.Play();
    }

    public static AudioClip[] GetClips()
    {
        return instance.audioClips;
    }


    // это просто заглушка, чтобы в других скриптах НЕ писать AudioManager.insatance.playSound(clip);

    public static void PlaySound(AudioClip clip)
    {
        instance.playSound(clip);
    }
}