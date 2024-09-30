using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioSource music;

    public AudioClip musicClip;

    public AudioClip clip;

    public AudioResource audioResource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeCurrentClip(AudioClip Clip)
    {
        clip = Clip;
    }

    public void ChangeMusic(AudioClip Music)
    {
        musicClip = Music;
        music.clip = musicClip;
        Debug.Log(Music);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
