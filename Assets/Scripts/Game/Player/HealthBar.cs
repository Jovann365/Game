using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Health health;
    public Sprite [] healthBar;
    private int currentHealth = 0;
    public SpriteRenderer healthRenderer;

    void Awake()
    {
        healthRenderer = GetComponent<SpriteRenderer>();
        health = player.GetComponent<Health>();
    }

    void Update()
    {
        if (currentHealth != Math.Abs(health.health - 4)) 
        { 
            currentHealth++; 
            healthRenderer.sprite = healthBar[currentHealth]; 
        }

    }
}
