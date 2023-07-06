using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuVolver : MonoBehaviour
{
    public void Volver()
    {
       Debug.Log("volviendo al menu incial");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
  
}
