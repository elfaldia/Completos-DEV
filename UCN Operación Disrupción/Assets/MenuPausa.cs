using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private static GameObject staticBotonPausa;
    private static GameObject staticMenuPausa;

    private void Awake()
    {
        staticBotonPausa = botonPausa;
        staticMenuPausa = menuPausa;
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public static void Reanudar()
    {
        Time.timeScale = 1f;
        staticBotonPausa.SetActive(true);
        staticMenuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
       Debug.Log("Cerrando juego");
       SceneManager.LoadScene(1);
    }
}
