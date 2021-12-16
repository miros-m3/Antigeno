using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float totalHealth = 100f;
    public Animator animator;

    private bool isAlive = true;
    protected float currentHealth;
    

    protected void Start()
    {
        isAlive = true;
        currentHealth = totalHealth;
    }

    public virtual void TakeDamage(int _damage) {
        currentHealth -= _damage;
        if(gameObject.tag == "Player")
            UIManager.instance.SetPlayerLife(currentHealth/totalHealth);
        if (currentHealth <= 0) {
            Death();
        }
    }

    public virtual void TakeHealth(int _damage)
    {
        currentHealth += _damage;
        if (gameObject.tag == "Player")
            UIManager.instance.SetPlayerLife(currentHealth / totalHealth);
        if (currentHealth >= 100)
        {
            
        }

    }

    public void Death() {
        Debug.Log(this.name + " is death");
        animator.SetTrigger("die");
        isAlive = false;
        StartCoroutine(CR_DeathTimer());
        if (gameObject.tag == "Player")
            GameManager.instance.LoseGame();
    }

    protected IEnumerator CR_DeathTimer() {
        float timer = 0;
        while (timer < 2f) {
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }

    public bool IsAlive() {
        return isAlive;
    }

}
