using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _soundSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        _soundSource = gameObject.AddComponent<AudioSource>();
        _soundSource.playOnAwake = false;
    }

    public void PlaySound(AudioClip clip, float volume = 0.6f)
    {
        if (clip == null) return;

        _soundSource.clip = clip;
        _soundSource.volume = volume;
        _soundSource.Play();
    }
}
