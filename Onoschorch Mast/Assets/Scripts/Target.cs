using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 25f;
    public AudioSource[] zombieSounds;
    private int healthUpgrade = 250;

    private void Update()
    {
        if (PointSystem.points >= healthUpgrade)
        {
            healthUpgrade += 250;
            health += 25; // increases enemy health by 25 every
                            // 100 points
        }
    }

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
        PointSystem.totalPoints += 20;
    }
    private void Start()
    {
        zombieSounds[Random.Range(0, 2)].Play();
    }
}