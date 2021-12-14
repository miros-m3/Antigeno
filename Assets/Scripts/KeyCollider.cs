using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : MonoBehaviour
{
    public GameObject player;
    public GameObject Door;
    public GameObject Key;


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
            Door.SetActive(false);

            Key.SetActive(false);

        }


    }
}
