using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    protected int vida;
    protected float velocidad;
    protected string nombre;
    protected int danyo;


    private void Start()
    {
        velocidad = 4.0f;
    }

    //Vida
    public void SetVida(int v)
    {
        vida = v;
    }

    public int GetVida()
    {
        return vida;
    }

    //Velocidad
    public void SetVelocidad(float vel)
    {
        velocidad = vel;
    }

    public float GetVelocidad()
    {
        return velocidad;
    }

    //Nombre
    public void SetNombre(string n)
    {
        nombre = n;
    }

    public string GetNombre()
    {
        return nombre;
    }


}
