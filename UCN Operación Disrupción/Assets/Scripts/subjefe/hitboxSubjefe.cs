using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxSubjefe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            other.gameObject.GetComponent<playerMovement>().TomarDano(20);
=======
            other.gameObject.GetComponent<playerMovement>().TomarDaño(20);
>>>>>>> Stashed changes
        }
    }
}
