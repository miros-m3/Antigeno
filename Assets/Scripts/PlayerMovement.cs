using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator playerAnimator;

    public float runSpeed = 40f;

    private float horizontalmove = 0f;
    private bool jump = false;

    private void Start()
    {
        controller.OnLandEvent.AddListener(OnLandedListener); 
    }

    private void Update()
    {

        if (!GetComponent<Health>().IsAlive())
            return;

        horizontalmove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            playerAnimator.SetTrigger("jump");
            playerAnimator.SetBool("isGrounded", false);
        }
    }

    private void FixedUpdate()
    {
        bool isMoving = (horizontalmove >= 1 || horizontalmove <= -1) ? true : false;
        playerAnimator.SetBool("isMoving", isMoving);
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnLandedListener() {
        playerAnimator.SetBool("isGrounded", true);
    }

}
