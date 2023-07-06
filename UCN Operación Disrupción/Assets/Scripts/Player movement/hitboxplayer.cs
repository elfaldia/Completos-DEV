using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D other) //se asigna el daño de cada enemigo
    {
        if(other.gameObject.CompareTag("Subjefe"))
        {
            other.gameObject.GetComponent<subjefe>().TomarDano(20);
            
        }
        else if(other.gameObject.CompareTag("Subjefe 2"))
        {
        other.gameObject.GetComponent<subjefe2>().TomarDano(20);
        }
        else if(other.gameObject.CompareTag("Subjefe 3"))
        {
            other.gameObject.GetComponent<subjefe3>().TomarDano(20);
        }
       else if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TomarDano(10);
        }
        else if(other.gameObject.CompareTag("Subjefe 4"))
        {
            other.gameObject.GetComponent<subjefe4>().TomarDano(20);
        }
        else if(other.gameObject.CompareTag("Final Boss"))
        {
            other.gameObject.GetComponent<finalboss>().TomarDano(25);
        }
    }
}
