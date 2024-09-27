using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : Enemigos
{
    private GameObject sonidoDanyo;


    private void Awake()
    {
        sonidoDanyo = (GameObject)GameObject.FindGameObjectWithTag("SonidoDanyoJugador");
    }


    private void Start()
    {
        velocidad = 1.5f;
        vida = 2;   
    }



    private void Update()
    {
        this.gameObject.transform.Translate(velocidad * Time.deltaTime, 0.0f, 0.0f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //movimiento y limites
        if (other.gameObject.tag == "LimMurcielagoDer")
        {
            velocidad *= -1;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (other.gameObject.tag == "LimMurcielagoIzq")
        {
            velocidad = Mathf.Abs(velocidad);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }


        //Accion cuando me da un disparo
        if(other.gameObject.tag =="DisparoPlayer")
        {
            sonidoDanyo.gameObject.GetComponent<AudioSource>().Play();
            vida--; //es igual a Vida - 1
            if(vida<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
