using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemigos
{



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="DisparoPlayer")
            
            {
            Destroy(this.gameObject);
            }
    }


}
