using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private WarpOverlay warpOverlay;
    private AudioManager audioManager;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    [SerializeField] private float duration = 2f;
    private Vector3 initialScale;
    private bool isScalingUp = true;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private GameObject warp;

    public void NotifyEnd(Enemy enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            End();
        }
    }

    private void End()
    {
        if (clip != null)
        {
            audioManager = FindFirstObjectByType<AudioManager>();
            audioManager.StopMusic();
            audioManager.ChangeMusic(clip);
            audioManager.StartMusic();
            warp.SetActive(true);
            StartCoroutine("ScaleCoroutine");
        }
    }

    private IEnumerator ScaleCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            Vector3 newScale = isScalingUp
                ? Vector3.Lerp(initialScale, targetScale, t)
                : Vector3.Lerp(targetScale, initialScale, t);
            targetTransform.localScale = newScale;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Toggle direction for the second half of the animation
        isScalingUp = !isScalingUp;

        // Wait for a brief pause before reversing the scale
        yield return new WaitForSeconds(4.0f);
        
        SceneManager.LoadScene("MainMenuTest");
        
        

    }
}
