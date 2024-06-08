using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip short1;
    [SerializeField] private AudioClip short2;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayShort1()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(short1);
    }

    public void PlayShort2()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(short2);
    }
}