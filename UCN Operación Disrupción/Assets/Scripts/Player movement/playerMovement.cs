using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : Fighter
{
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    [SerializeField]private BarraVida BarraVida;

    Vector2 cntrl;
    void Start()
    {
        vida=vidaMaxima;
        BarraVida.inicioBarra(vida);
    }

    void Update()
    {
        cntrl = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        if(cntrl.x != 0){
            sr.flipX = cntrl.x < 0;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("sendPunch");
        }
        anim.SetBool("isDefense", Input.GetKey(KeyCode.X));
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punch")&& !anim.GetCurrentAnimatorStateInfo(0).IsName("GetPunch")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Defense"))
        {
        anim.SetBool("isWalking", cntrl.magnitude != 0);
        rb.velocity = new Vector2(cntrl.x*horizontalSpeed, cntrl.y * verticalSpeed);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimitsY.y,LimitsY.x),transform.position.z);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }  
        
    }
     public void TomarDaño(float daño)
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Defense")){
      
        vida-=daño;
        //anim.setTrigger("getPunch");
        BarraVida.vidaActual(vida);
        if(vida==0)
        {
            anim.SetTrigger("Death");
            Destroy(gameObject,1.8f);
        }
    
    }}
}
