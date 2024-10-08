using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
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

    [SerializeField] private Volume volume;

    [SerializeField] private Vignette vignette;

    [SerializeField] private float vignetteStrength;

    [SerializeField] private float vignetteLastTime;

    [SerializeField] private AnimationCurve curve1;
    
    [SerializeField] private AnimationCurve curve2;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = FindFirstObjectByType<Camera>();
        audioManager = FindFirstObjectByType<AudioManager>();
        volume = FindFirstObjectByType<Volume>();
        volume.profile.TryGet(out vignette);
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
                float vignetteIntensity = curve1.Evaluate(Time.realtimeSinceStartup - vignetteLastTime);
                vignette.intensity.value = vignetteIntensity;
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() || other.GetComponent<PlayerController>())
        {
            audioManager.StopMusic();
            audioManager.OriginalMusic();
            camera.fieldOfView = 60;
            vignetteLastTime = Time.realtimeSinceStartup;
            T = 0;
            Debug.Log("notBossTime");
            started = false;
            vignette.intensity.value = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
