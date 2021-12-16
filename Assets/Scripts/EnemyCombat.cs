using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Enemy Attack References")]
    public Animator enemyAnimator;
    public Transform attackPoint;
    [Header("Enemy Attack Settings")]
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public int attackDamage = 20;
    public float attackCooldown = 2f;
    public AudioSource Listener;
    public AudioClip PainSound;
    [HideInInspector]
    public bool isInAttackRange = false;

    private bool isAttackOnCooldown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<EnemyMovement>().playerObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<EnemyMovement>().playerObject = null;
        }
    }

    void Update()
    {
        if (!GetComponent<Health>().IsAlive())
            return;

        if (isInAttackRange && !isAttackOnCooldown)
        {
            StartCoroutine(StartAttackCooldown());
            StartCoroutine(CR_Attack());
            //Attack();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void Attack()
    {
        //Detectar enemigos
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        //Hacer daño a enemigos
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Health>().TakeDamage(attackDamage);
            Debug.Log(player.gameObject.name + " has taken " + attackDamage + " of damage.");
            Listener.PlayOneShot(PainSound);
        }

        
    }

    private IEnumerator CR_Attack()
    {
        //Ejecutar la animacion
        if (enemyAnimator != null)
            enemyAnimator.SetTrigger("attack");

        float timer = 0;
        while (timer < 0.4f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Attack();
    }

    private IEnumerator StartAttackCooldown() {
        isAttackOnCooldown = true;
        float timeCounter = 0;
        while (timeCounter < attackCooldown) {
            timeCounter += Time.deltaTime;
            yield return null;
        }
        isAttackOnCooldown = false;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

}
