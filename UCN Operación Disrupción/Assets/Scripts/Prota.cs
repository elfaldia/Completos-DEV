using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prota : MonoBehaviour
{

    // Start is called before the first frame update
    private Rigidbody2D RigidBody2D;
    public Animator animator;
    Vector2 movement;
    public float moveSpeed = 5f;
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        RigidBody2D.MovePosition(RigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
