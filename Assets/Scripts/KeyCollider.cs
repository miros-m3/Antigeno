using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class KeyCollider : MonoBehaviour
{
    public GameObject player;
    public GameObject Door;
    public GameObject Key;
    public Sprite KeyImageVisible;
   // public Sprite KeyImageHiden;
    public GameObject KeyUI;
    

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

            KeyUI.GetComponent<UnityEngine.UI.Image>().sprite = KeyImageVisible;
        }


    }
}
