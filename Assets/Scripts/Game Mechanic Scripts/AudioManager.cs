using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source---------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip background;
    public AudioClip jumpSFX;
    public AudioClip gemSFX;
    public AudioClip buttonSFX;
    void Start()
    {
        //Starts the game by playing the BGM
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        //Allows for SFX to be played in other scripts
        sfxSource.PlayOneShot(clip);
    }
    public void StopBGM()
    {
        //Stops the background music
        musicSource.Stop();
    }
}
