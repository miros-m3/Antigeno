using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxigeno : MonoBehaviour
{
    public GameObject player;
    public int HealthPoints = 20;

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
                player.GetComponent<Health>().TakeHealth(HealthPoints);
                Debug.Log(player.gameObject.name + " has recuperated " + HealthPoints + " of Health.");
            Destroy(this.gameObject);
        }
        }

        
}
