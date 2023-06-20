using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateMelee : MonoBehaviour
{
    
    private Transform controladorGolpe;
    private float radioGolpe;
    private float dañoGolpe;

    void Update(){
        Golpe();
    }
    public void Golpe () {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach(Collider2D colisionador in objetos){
            if(colisionador.CompareTag("Enemy")){
                //colisionador.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe);
                return;
            }
        }
    }
}
