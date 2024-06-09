using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource shopEntryOutAudioSource;
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioClip short1;
    [SerializeField] private AudioClip short2;
    public static bool IsSoundOn = true;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        shopEntryOutAudioSource = GetComponent<AudioSource>();
    }

    public void ToggleSound()
    {
        shopEntryOutAudioSource.mute = !shopEntryOutAudioSource.mute;
        backgroundAudioSource.mute = !backgroundAudioSource.mute;
        IsSoundOn = !IsSoundOn;
    }

    public void PlayShort1()
    {
        if (shopEntryOutAudioSource.isPlaying)
        {
            return;
        }

        shopEntryOutAudioSource.PlayOneShot(short1);
    }

    public void PlayShort2()
    {
        if (shopEntryOutAudioSource.isPlaying)
        {
            return;
        }

        shopEntryOutAudioSource.PlayOneShot(short2);
    }
}