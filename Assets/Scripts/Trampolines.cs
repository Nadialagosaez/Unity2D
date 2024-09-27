using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolines : MonoBehaviour
{

    public float fuerzaSalto;
    private GameObject sonidoSalto;

    private void Awake()
    {
        sonidoSalto = (GameObject) GameObject.FindGameObjectWithTag("SonidoSalto");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            sonidoSalto.GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerzaSalto);
        }
    }
}
