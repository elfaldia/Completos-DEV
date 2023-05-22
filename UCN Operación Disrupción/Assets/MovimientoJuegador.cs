using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJuegador : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Movimiento")]

    private float movimientoHorizontal = 0f; 

    [SerializeField]private float velocidadDeMovimiento;

    [Range(0,0.3f)][SerializeField]private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    private void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update(){

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

    }

    private void FixedUpdate(){
        //Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
    }

    private void Mover(float mover){
        Vector3 velocidadObjetivo = new Vector2(mover,rb2d.velocity.y); 
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity,velocidadObjetivo,ref velocidad, suavizadoDeMovimiento);

        if(mover > 0  &&  !mirandoDerecha){
            //Girar
            Girar();
        }else if(mover < 0 && mirandoDerecha){
            //Girar
            Girar();
        }

    }

    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;  
    }

}
