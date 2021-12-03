using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Health
{
    public Image enemyLifeImage;
    public override void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (gameObject.tag == "Enemy")
            enemyLifeImage.fillAmount = (currentHealth / totalHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
    }
}
