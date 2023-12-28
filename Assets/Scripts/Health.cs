using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    [NonSerialized] private Vector3 originalScale;
    void Start()
    {
        Debug.Log("Health.cs start");
        currentHealth = maxHealth;
        originalScale = transform.localScale;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        } 
        
        Transform healthBar = gameObject.transform.Find("HealthBar").transform;
        // вычисляем, на сколько нужно уменьшить хп бар (пропорция).
        healthBar.localScale = new Vector3(
            originalScale.x * currentHealth  / maxHealth,
            healthBar.localScale.y,
            healthBar.localScale.z
        );
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}