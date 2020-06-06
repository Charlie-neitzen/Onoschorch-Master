using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private int xPos;
    private int zPos;
    private int kills = 0;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            kills++;
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{kills} kills.");
    }
}