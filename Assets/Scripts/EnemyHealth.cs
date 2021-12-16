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
            EnemyDeath();
        }
    }
    public void EnemyDeath()
    {
        Debug.Log(this.name + " is death");
        StartCoroutine(CR_DeathTimer());
        if (gameObject.tag == "Enemy")
            GameManager.instance.WinGame();
    }
}
