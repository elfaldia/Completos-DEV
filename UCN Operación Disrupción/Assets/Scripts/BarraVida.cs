using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        
    }

  
    public void maxVida(float vidaMaxima)
    {
        slider.maxValue=vidaMaxima;
    }
    public void vidaActual(float cantidad)
    {
        slider.value=cantidad;
    }
    public void inicioBarra(float cantidad)
    {
        slider=GetComponent<Slider>();
        maxVida(cantidad);
        vidaActual(cantidad);
    }
}
