using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public AudioSource[] zombieSounds;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        PointSystem.points += 20;
    }
    private void Start()
    {
        zombieSounds[Random.Range(0, 2)].Play();
    }
}