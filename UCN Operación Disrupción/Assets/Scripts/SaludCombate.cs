using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludCombate : MonoBehaviour
{
   [SerializeField] private float vida;
   [SerializeField] private float vidaMaxima;
   [SerializeField]private BarraVida BarraVida;
    void Start()
    {
        vida=vidaMaxima;
        BarraVida.inicioBarra(vida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TomarDa�o(float da�o)
    {
        vida-=da�o;
        BarraVida.vidaActual(vida);
        if(vida<=0)
        {
            Destroy(gameObject);
        }
    }
}
