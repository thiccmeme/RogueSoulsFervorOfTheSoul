using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioSource music;

    public AudioClip musicClip;

    private AudioClip originalMusic;

    public AudioClip clip;

    public AudioClip enemyShoot;

    public AudioResource audioResource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalMusic = musicClip;
    }

    public void ChangeCurrentClip(AudioClip Clip)
    {
        clip = Clip;
    }

    public void ChangeEnemyClip(AudioClip Clip)
    {
        enemyShoot = Clip;
        source.PlayOneShot(Clip);
    }

    public void OriginalMusic()
    {
        musicClip = originalMusic;
        music.clip = musicClip;
        music.Play();
    }

    public void ChangeMusic(AudioClip Music)
    {
        musicClip = Music;
        music.clip = musicClip;
    }

    public void PlayClip()
    {
        source.PlayOneShot(clip);
    }

    public void StartMusic()
    {
        music.clip = musicClip;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void StopClip()
    {
        source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
