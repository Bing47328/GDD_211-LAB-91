using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private string currentState;

    private float speed;

    private Vector2 move;



    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");

        move.Normalize();

        rb.velocity = new Vector3(move.x * speed, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector2(0, 90);
            ChangingAnimationState("Running");
            speed = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector2(0, 270);
            ChangingAnimationState("Walking");
            speed = .2f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            ChangingAnimationState("Backflip");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ChangingAnimationState("Crouch");
        }
        else
        {
            ChangingAnimationState("Idle");
        }


    }

    private void ChangingAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
    
}
