using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpObject : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private GameObject warp;
    [SerializeField] private Transform warpTarget;
    [SerializeField] private Transform warpDestination;
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    [SerializeField] private float duration = 2f;
    [SerializeField] private bool hasRanTwice = false;

    private Vector3 initialScale;
    private bool isScalingUp = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            hasRanTwice = false;
            warpTarget = other.transform;
            warp.SetActive(true);
            StartCoroutine(ScaleCoroutine());
            Invoke("Teleport", duration);
        }
    }
    
    private void Start()
    {
        initialScale = targetTransform.localScale;
    }

    private IEnumerator ScaleCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            Vector3 newScale = isScalingUp ? Vector3.Lerp(initialScale, targetScale, t) : Vector3.Lerp(targetScale, initialScale, t);
            targetTransform.localScale = newScale;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Toggle direction for the second half of the animation
        isScalingUp = !isScalingUp;

        // Wait for a brief pause before reversing the scale
        yield return new WaitForSeconds(0.25f);

        // Restart the coroutine for the reverse animation
        if (hasRanTwice != true)
        {
            StartCoroutine(ScaleCoroutine());
            hasRanTwice = true;
            Invoke("Stop", duration);
        }
    }

    private void Stop()
    {
        warp.SetActive(false);
    }

    private void Teleport()
    {
        warpTarget.position = warpDestination.position;
    }
    
}