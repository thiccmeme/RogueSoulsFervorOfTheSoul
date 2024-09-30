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
            StartCoroutine("ArenaFov");
            
            Debug.Log("bosstime");
        }
    }

    IEnumerator ArenaFov()
    {
        while (fov >= startFov - 0.01f)
        {
            camera.fieldOfView = Mathf.Lerp(startFov, fov, timetolerp);
        }

        yield return null;
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
