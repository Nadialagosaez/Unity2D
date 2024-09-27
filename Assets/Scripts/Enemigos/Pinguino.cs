using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinguino : Enemigos
{

    public GameObject disparoPinguino;
    private GameObject disparoPinguinoClon;
    private GameObject creadorDeDisparos;

    //Lanzamiento de bolas
    public float esperaPrimerDisparo;
    public float repeticionDisparos;
    public float fuerzaDisparo;
    public float tiempoAutodestriccion;

    //Referencia player
    private GameObject player;

    //Sonido Danyo
    private GameObject sonidoDanyo;


    private void Awake()
    {
        player = (GameObject) GameObject.FindGameObjectWithTag("Player");
        sonidoDanyo = (GameObject)GameObject.FindGameObjectWithTag("SonidoDanyoJugador");
    }

    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
        creadorDeDisparos = this.gameObject.transform.GetChild(0).gameObject;
        InvokeRepeating("LanzarBolas", esperaPrimerDisparo, repeticionDisparos);
    }

    private void LanzarBolas()
    {
        if (player != null)
        {
            if (player.gameObject.transform.position.x < this.gameObject.transform.position.x)
            {
                disparoPinguinoClon = (GameObject)Instantiate(disparoPinguino, creadorDeDisparos.gameObject.transform.position, Quaternion.identity);
                disparoPinguinoClon.GetComponent<Rigidbody2D>().velocity = new Vector2(fuerzaDisparo, 0.0f);
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                disparoPinguinoClon = (GameObject)Instantiate(disparoPinguino, creadorDeDisparos.gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 180.0f));
                disparoPinguinoClon.GetComponent<Rigidbody2D>().velocity = new Vector2(-fuerzaDisparo, 0.0f);
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            Destroy(disparoPinguinoClon.gameObject, tiempoAutodestriccion);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DisparoPlayer")

        {
            sonidoDanyo.gameObject.GetComponent<AudioSource>().Play();
            vida--; //es igual a Vida - 1
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
