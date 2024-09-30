using System;
using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class BossArenaTrigger : MonoBehaviour
{

    [SerializeField] private Camera camera;

    [SerializeField] private AudioClip audioClip;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private float fov;

    [SerializeField] private float timetolerp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = FindFirstObjectByType<Camera>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            audioManager.ChangeMusic(audioClip);
            audioManager.StartMusic();
            camera.fieldOfView = Mathf.Lerp(60f, fov, timetolerp);
            Debug.Log("bosstime");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() || other.GetComponent<PlayerController>())
        {
            audioManager.StopMusic();
            camera.fieldOfView = 60;
            Debug.Log("notBossTime");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
