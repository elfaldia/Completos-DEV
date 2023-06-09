using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    
    //public Animator animator;
    private float vida;

    public Transform objetivo;
    public bool perseguir;
    public float distancia;
    public float distanciaAbs;
    public float moveSpeed = 1f;

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        distancia = objetivo.position.x - transform.position.x;
        distanciaAbs = Mathf.Abs(distancia);

        if(distancia > 0 && distancia<10) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-2,2,1);
        }
        if(distancia < 0 && distancia>-10){
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(2,2,1);
        }
        if(perseguir) {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, moveSpeed * Time.deltaTime);
        }

        if(distanciaAbs < 2) {
            perseguir = true;
        }else{
            perseguir = false;
        }
    }

    public void TomarDaño(float daño){
        vida -= daño;
        if(vida <= 0){
            Muerte();
        }
    }

    private void Muerte(){
        //animator.SetTrigger("Muerte");
    }
}
