using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HazardDamage : MonoBehaviour

{
    public int attackDamage = 50;
    public GameObject player;


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
 
        private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detectar enemigos
        if (collision.collider.tag == "Player")
        {
            player.GetComponent<Health>().TakeDamage(attackDamage);
            Debug.Log(player.gameObject.name + " has taken " + attackDamage + " of damage.");
            
        }


    }
}
