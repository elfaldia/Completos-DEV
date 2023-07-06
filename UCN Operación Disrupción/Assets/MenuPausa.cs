using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    private GameObject staticBotonPausa;
    private GameObject staticMenuPausa;

    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    private void Awake()
    {
        juegoPausado = false;
        staticBotonPausa = botonPausa;
        staticMenuPausa = menuPausa;
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        staticBotonPausa.SetActive(true);
        staticMenuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        SceneManager.LoadScene(1);
    }
}
