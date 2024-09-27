using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DTerminarDisparo : MonoBehaviour    
{

    public void DesactivarTerminarDisparo()
    {
        this.gameObject.GetComponent<Animator>().SetBool("terminarDisparo", false);
    }

    public void TerminarDisparoPadre()
    {
        this.gameObject.transform.parent.GetComponent<Player2D>().TerminarDisparo();
        
    }
}
