using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSeleccion : MonoBehaviour
{
    public void nivel1()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(2);
    }

    public void nivel2()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(3);
    }

    public void nivel3()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(4);
    }

    public void nivel4()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(5);
    }

    public void nivel5()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(6);
    }
}
