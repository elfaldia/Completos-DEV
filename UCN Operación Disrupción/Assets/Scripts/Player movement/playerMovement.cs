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
        
        anim.SetBool("isWalking", cntrl.magnitude != 0);
        rb.velocity = new Vector2(cntrl.x*horizontalSpeed, cntrl.y * verticalSpeed);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LimitsY.y,LimitsY.x),transform.position.z);
    }
}
