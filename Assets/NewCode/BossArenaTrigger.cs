using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class BossArenaTrigger : MonoBehaviour
{

    [SerializeField] private Camera camera;

    [SerializeField] private AudioClip audioClip;

    [SerializeField] private AudioManager audioManager;

    [SerializeField] private float fov;

    [SerializeField] private float startFov;

    [SerializeField] private float timetolerp;

    [SerializeField] private bool started;

    [SerializeField] private float T;
    
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
            started = true;
            if (started)
            {
                audioManager.StopMusic();
                audioManager.ChangeMusic(audioClip);
                audioManager.StartMusic();
            }
            Debug.Log("bosstime");
        }
    }

    private void FixedUpdate()
    {
        if (started)
        {
            if (T != 1)
            {
                T += 0.05f;
                camera.fieldOfView = Mathf.Lerp(startFov, fov, T);
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() || other.GetComponent<PlayerController>())
        {
            audioManager.StopMusic();
            camera.fieldOfView = 60;
            T = 0;
            Debug.Log("notBossTime");
            started = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
