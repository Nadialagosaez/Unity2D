using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject panelPausa;
    private GameObject panelDerrota;
    private GameObject panelVictoria;

    private GameObject barraVida;
    private GameObject numDisparosText;
    private GameObject numDiamantesText;


    private int estadoPanelPausa;


    private void Awake()
    {
        panelPausa = (GameObject)GameObject.FindGameObjectWithTag("PanelPausa");
        panelDerrota = (GameObject)GameObject.FindGameObjectWithTag("PanelDerrota");
        panelVictoria = (GameObject)GameObject.FindGameObjectWithTag("PanelVictoria");


        barraVida = (GameObject)GameObject.FindGameObjectWithTag("BarraVida");
        numDisparosText = (GameObject)GameObject.FindGameObjectWithTag("NumDisparosText");
        numDiamantesText = (GameObject)GameObject.FindGameObjectWithTag("NumDiamantesText");

        estadoPanelPausa = 0;



        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }

        if (panelDerrota != null)
        {
            panelDerrota.SetActive(false);
        }

        if (panelVictoria != null)
        {
            panelVictoria.SetActive(false);
        }


        //Reiniciar vida, disparos y diamantes
        General.SetNumVidas(General.GetMaxNumVidas());
        General.SetNumDisparos(General.GetMaxNumDisparos());
        General.SetNumDiamantes(General.GetMinNumDiamantes());

        SetNumDisparosText();
        SetNumDiamantesText();
        SetBarraVida(General.GetNumVidas());


    }

    public void MostrarPanelPausa(int estado)
    {
        if (!panelPausa.activeSelf)
        {
            panelPausa.SetActive(true);
        }
        if (estado == 1)
        {
            panelPausa.GetComponent<Animator>().SetInteger("estadoPanelPausa", 1);
        }
        else if (estado == 2)
        {
            panelPausa.GetComponent<Animator>().SetInteger("estadoPanelPausa", 2);
        }
        else
        {
            Time.timeScale = 1.0f;
            panelPausa.GetComponent<Animator>().SetInteger("estadoPanelPausa", 0);
        }
    }

    public void MostrarPanelDerrota()
    {
        panelDerrota.SetActive(true);
    }

    public void MostrarPanelVictoria()
    {
       
       panelVictoria.SetActive(true);
        
    }

    //Barra de vidas
    public void SetBarraVida(int num)
    {
        if (barraVida != null)
        {

            barraVida.GetComponent<Slider>().value = num;

            if (barraVida.GetComponent<Slider>().value >= General.GetMaxVida())
            {
                barraVida.GetComponent<Slider>().value = General.GetMaxVida();
            }
            if (barraVida.GetComponent<Slider>().value <= General.GetMinVida())
            {
                barraVida.GetComponent<Slider>().value = General.GetMinVida();
            }

        }
    }

    public int GetBarraVida()
    {
        return int.Parse(barraVida.GetComponent<Slider>().value.ToString());

    }

    //Numero Disparos
    public void SetNumDisparosText()
    {
        if (numDisparosText != null)
        {
            numDisparosText.GetComponent<Text>().text = General.GetNumDisparos().ToString();

        }
    }


    //Numero Diamantes
    public void SetNumDiamantesText()
    {
        if (numDiamantesText != null)
        {
            numDiamantesText.GetComponent<Text>().text = General.GetNumDiamantes().ToString();
        }
    }



    //Botones Menu Principal
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("00_creditos");
    }

    public void Salir()
    {
        Application.Quit();

    }

    //Botones panel derrota
    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("02_Menu_ppal");
    }

    //Boton Pasar de nivel
    public void PasarDeNivel(string nombreDeNivel)
    {
        SceneManager.LoadScene(nombreDeNivel);
    }

    //mostrar panel de pausa (ESC)
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(estadoPanelPausa == 0)
            {
                estadoPanelPausa = 1;
                
            }
            else
            {
                estadoPanelPausa = 0;
                Time.timeScale = 1.0f;

            }

            MostrarPanelPausa(estadoPanelPausa);
        }
    }
}
