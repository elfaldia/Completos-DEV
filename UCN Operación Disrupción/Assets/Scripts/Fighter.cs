using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Fighter : MonoBehaviour
{
    protected static Vector2 LimitsY = new Vector2(-1.42f, -7.57f); 

    [SerializeField]
    protected float verticalSpeed;
    [SerializeField]
    protected float horizontalSpeed = 1;

    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
}
