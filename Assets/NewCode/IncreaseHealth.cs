using System;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private int healthToIncrease;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            PlayerStats targetPlayer = other.GetComponent<PlayerStats>();
            targetPlayer.IncreaseHealth(healthToIncrease);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
