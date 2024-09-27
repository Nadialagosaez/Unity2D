using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{


    private float h;
    private float v;
    private float f;


    public float velocidadHorizontal;
    public float fuerzaVertical;

    private bool estaSaltando;

    public bool estoyMuerta;

    private GameObject acumulador;

    //Disparo
    public GameObject disparoPlayer;
    private GameObject disparoPlayerClon;

    private GameObject creadorDisparoDerecha;
    private GameObject creadorDisparoIzquierda;

    public float coolDone;
    private bool estaDisparando;
    public float fuerzaDisparo;
    public float tiempoDestruccionDisparo;

    //Sonidos
    private GameObject sonidoDisparos;
    private GameObject sonidoRecargaDisparos;
    private GameObject sonidoDiamantes;
    private GameObject sonidoDanyoJugador;
    private GameObject sonidoRecogerVida;
    private GameObject sonidoSalto;

    //Limite Inferior
    public float limiteInferior;

    //Destruccion Rigibody al morir (Frenar camara)
    public float tiempoEsperaDestruccionRigi;


    void Awake()
    {
        acumulador = (GameObject)GameObject.FindGameObjectWithTag("Acumulador"); 
        creadorDisparoDerecha = this.gameObject.transform.GetChild(1).gameObject;
        creadorDisparoIzquierda = this.gameObject.transform.GetChild(2).gameObject;

        sonidoDisparos = (GameObject)GameObject.FindGameObjectWithTag("SonidoDisparo");
        sonidoRecargaDisparos = (GameObject)GameObject.FindGameObjectWithTag("SonidoRecargaDisparos");
        sonidoDiamantes = (GameObject)GameObject.FindGameObjectWithTag("RecogerDiamantes");
        sonidoDanyoJugador = (GameObject)GameObject.FindGameObjectWithTag("SonidoDanyoJugador");
        sonidoRecogerVida = (GameObject)GameObject.FindGameObjectWithTag("SonidoRecogerVida");
        sonidoSalto = (GameObject)GameObject.FindGameObjectWithTag("SonidoSalto");


    }


    // Start is called before the first frame update
    void Start()
    {
        estaSaltando = false;
        estoyMuerta = false;

        estaDisparando = false;


    }

    public void TerminarDisparo()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("terminarDisparo", true);

        if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
        {
            disparoPlayerClon = (GameObject)Instantiate(disparoPlayer, creadorDisparoDerecha.transform.position, Quaternion.identity);
            disparoPlayerClon.GetComponent<Rigidbody2D>().velocity = new Vector2(fuerzaDisparo, 00f);
        }
        else
        {
            disparoPlayerClon = (GameObject)Instantiate(disparoPlayer, creadorDisparoIzquierda.transform.position, Quaternion.Euler(0.0f, 0.0f, 180.0f));
            disparoPlayerClon.GetComponent<Rigidbody2D>().velocity = new Vector2(-fuerzaDisparo, 00f);
        }
        Destroy(disparoPlayerClon, tiempoDestruccionDisparo);



        Invoke("DisparoFinalizado", coolDone);
    }


    private void DisparoFinalizado()
    {
        estaDisparando = false;
    }


    public void EsperarMuerte()
    {
        acumulador.GetComponent<UIManager>().MostrarPanelDerrota();
    }


    // Update is called once per frame
    void Update()
    {

        if (!estoyMuerta)
        { 
            h = Input.GetAxis("Horizontal") * velocidadHorizontal * Time.deltaTime;
            v = Input.GetAxis("Jump");
            f = Input.GetAxis("Fire1");

            this.gameObject.transform.Translate(h, 0.0f, 0.0f);



            if(h>0)
            {
                this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                if (!estaSaltando)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 3);
                }
            
            }
            else if (h<0)
            {
                this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true; if (!estaSaltando)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 3);
                }
            }
            else
            {
                if (!estaSaltando)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 0);
                }
            }


            if (!estaSaltando)
            {
                if (v>0)
                {
                    sonidoSalto.GetComponent<AudioSource>().Play();
                    this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 1);
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, fuerzaVertical);
                    estaSaltando = true;

                 }

            }

            if (f>0.0f)
            {
                if (!estaDisparando)
                {
                    estaDisparando = true;
                    
                    if (General.GetNumDisparos() <= 0)
                    {
                        Debug.Log("No tengo disparos");
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("disparar");
                        sonidoDisparos.GetComponent<AudioSource>().Play();
                        General.SetNumDisparos(General.GetNumDisparos() - 1);
                        acumulador.GetComponent<UIManager>().SetNumDisparosText();
                    }


                    
                }

            }

            if(this.gameObject.transform.position.y<limiteInferior)
            {
                this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 4);
                estoyMuerta = true;
            }
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 4);
            
            Invoke("EsperarMuerte", 1.5f);

        }

    }

    private void DestroyRigibody2D()
    {
        Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        
    }

    private void EstoyMuriendo()
    {
        if(General.GetNumVidas()<= 0)
        {
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 4);
            estoyMuerta = true;
            Invoke("DestroyRigibody2D", 1.5f);
        }
    }

    //chocar contra objeto rigi
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Suelo
        if (other.gameObject.tag == "Suelo")
        {
            estaSaltando = false;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetInteger("statePlayer", 0);
           
        }


        //Murcielagos
        if (other.gameObject.tag == "Murcielagos")
        {
            General.SetNumVidas(General.GetNumVidas() - General.GetDanyoMurcielago());
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoDanyoJugador.GetComponent<AudioSource>().Play();
            if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }

            EstoyMuriendo();

        }


        //Robots
        if (other.gameObject.tag == "Robots")
        {
            
            General.SetNumVidas(General.GetNumVidas() - General.GetDanyoRobot()); 
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoDanyoJugador.GetComponent<AudioSource>().Play();

            if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }

            EstoyMuriendo();
        }

        //Caparazon
        if (other.gameObject.tag == "Caparazon")
        {

            General.SetNumVidas(General.GetNumVidas() - General.GetDanyoCaparazon());
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoDanyoJugador.GetComponent<AudioSource>().Play();

            if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }

            EstoyMuriendo();
        }

        //Pinguino
        if (other.gameObject.tag == "Pinguino")
        {

            General.SetNumVidas(General.GetNumVidas() - General.GetDanyoPinguino());
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoDanyoJugador.GetComponent<AudioSource>().Play();

            if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }

            EstoyMuriendo();
        }


        //Plataforma Horizontal
        if (other.gameObject.name == "PlataformaH")
            {
                this.gameObject.transform.SetParent(other.gameObject.transform);
            }

        //Plataforma Vertical
        if (other.gameObject.name == "PlataformaV")
        {
            this.gameObject.transform.SetParent(other.gameObject.transform);
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "PlataformaH")
        {
            this.gameObject.transform.SetParent(null);
        }
        if (other.gameObject.name == "PlataformaV")
        {
            this.gameObject.transform.SetParent(null);
        }
    }


    //Atravesar trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Disparos
        if(other.gameObject.tag == "RecargaDisparos")
        {
            General.SetNumDisparos(General.GetNumDisparos() + General.GetRecargaDisparos());
            sonidoRecargaDisparos.GetComponent<AudioSource>().Play();

            if (General.GetNumDisparos()>General.GetMaxNumDisparos())
            {
                General.SetNumDisparos(General.GetMaxNumDisparos());
            }

            
            acumulador.GetComponent<UIManager>().SetNumDisparosText();
            Destroy(other.gameObject);
        }

        //Diamantes
        if (other.gameObject.tag == "Diamantes")
        {
            General.SetNumDiamantes(General.GetNumDiamantes() + General.GetRecargaDiamantes());
            acumulador.GetComponent<UIManager>().SetNumDiamantesText();
            sonidoDiamantes.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }

        //Vidas
        if (other.gameObject.tag == "Vidas")
        {
            General.SetNumVidas(General.GetNumVidas() + General.GetRecargaVida());
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoRecogerVida.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }


        //Victoria
        if(other.gameObject.tag == "Victoria")
        {
            acumulador.GetComponent<UIManager>().MostrarPanelVictoria();
            Destroy(this.gameObject);
        }

        //DisparoPinguino
        if (other.gameObject.tag == "DisparoPinguino")
        {

            General.SetNumVidas(General.GetNumVidas() - General.GetDanyoDisparoPinguino());
            acumulador.GetComponent<UIManager>().SetBarraVida(General.GetNumVidas());
            sonidoDanyoJugador.GetComponent<AudioSource>().Play();

            if (!this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(General.GetFuerzaDayoPlayerX(), General.GetFuerzaDayoPlayerY());
            }

            EstoyMuriendo();
        }
    }
    



}
