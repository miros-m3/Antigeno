using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackCooldown;
    public int attackDamage = 20;

    private bool isAttackOnCooldown = false;

    void Update()
    {
        if (!GetComponent<Health>().IsAlive())
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttackOnCooldown) {
            //Attack();
            StartCoroutine(StartAttackCooldown());
            StartCoroutine(CR_Attack());
        }
    }

    private void Attack() {

        //Detectar enemigos
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Hacer daño a enemigos
        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            Debug.Log(enemy.gameObject.name + " has taken " + attackDamage + " of damage.");
        }
    }

    private IEnumerator CR_Attack() {
        //Ejecutar la animacion
        playerAnimator.SetTrigger("attack");

        //Ejecuto el audio
        SoundManager.instance.PlaySFXAudioClip("GolpeHeroe");

        float timer = 0;
        while (timer < 0.4f) {
            timer += Time.deltaTime;
            yield return null;
        }
        Attack();
    }

    private IEnumerator StartAttackCooldown()
    {
        isAttackOnCooldown = true;
        float timeCounter = 0;
        while (timeCounter < attackCooldown)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }
        isAttackOnCooldown = false;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

}
