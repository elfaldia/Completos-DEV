using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class playerMovement : MonoBehaviour
{
    // min -7.57
    // max -1.42

    static Vector2 LimitsY = new Vector2(-1.42f,-7.57f);

    [SerializeField]
    float verticalSpeed;
    [SerializeField]
    float horizontalSpeed;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    Vector2 cntrl;

    void Update()
    {
        cntrl = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        if(cntrl.x != 0){
            sr.flipX = cntrl.x < 0;
        }
        
        anim.SetBool("isWalking", cntrl.magnitude != 0);
        rb.velocity = new Vector2(cntrl.x*horizontalSpeed, cntrl.y * verticalSpeed);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimitsY.y,LimitsY.x),transform.position.z);
    }
}
