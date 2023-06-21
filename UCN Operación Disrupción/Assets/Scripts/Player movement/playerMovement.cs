using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : Fighter
{

    Vector2 cntrl;

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
}
