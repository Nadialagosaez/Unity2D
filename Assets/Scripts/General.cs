using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{

    private static int numVidas = 10;
    private static int maxNumVidas = 10;
    private static int numDisparos = 30;
    private static int maxNumDisparos = 30;
    private static int numDiamantes = 0;
    private static int minNumDiamantes = 0;


    //Recarga Diamantes
    private static int recargaDiamantes = 1;


    //Recarga disparos
    private static int recargaDisparos = 5;
 
    //Barra de Vidas
    private static int minVida = 0;
    private static int maxVida = 10;
    //Recarga de Vida
    private static int recargaVida = 2;


    //Daño Jugador
    private static int danyoMurcielago = 2;
    private static int danyoRobot = 1;
    private static int danyoCaparazon = 1;
    private static int danyoPinguino = 3;
    private static int danyoDisparoPinguino = 1;

    private static float fuerzaDayoPlayerX = 3.0f;
    private static float fuerzaDayoPlayerY = 3.0f;




    //Max num vidas
    public static int GetMaxNumVidas()
    {
        return maxNumVidas;
    }


    //Min num diamantes
         public static int GetMinNumDiamantes()
    {
        return minNumDiamantes;
    }

    //Recarga de vida
    public static int GetRecargaVida()
    {
        return recargaVida;
    }

    public static void SetRecargaVida(int rV)
    {
        recargaVida = rV;
    }


    //Fuerza daño
    //X
    public static float GetFuerzaDayoPlayerX()
    {
        return fuerzaDayoPlayerX;
    }

    public static void SetFuerzaDayoPlayerX(float fDX)
    {
        fuerzaDayoPlayerX = fDX;
    }
    //Y
    public static float GetFuerzaDayoPlayerY()
    {
        return fuerzaDayoPlayerY;
    }

    public static void SetFuerzaDayoPlayerY(float fDY)
    {
        fuerzaDayoPlayerY = fDY;
    }


    //Enemigos
    public static int GetDanyoMurcielago()
    {
        return danyoMurcielago;
    }

    public static void SetDanyoMurcielago(int dMur)
    {
        danyoMurcielago = dMur;
    }


    public static int GetDanyoRobot()
    {
        return danyoRobot;
    }

    public static void SetDanyoRobot(int dRob)
    {
        danyoRobot = dRob;
    }


    public static int GetDanyoCaparazon()
    {
        return danyoCaparazon;
    }

    public static void SetDanyoCaparazon(int dCap)
    {
        danyoCaparazon = dCap;
    }


    public static int GetDanyoPinguino()
    {
        return danyoPinguino;
    }

    public static void SetDanyoPinguino(int dPin)
    {
        danyoPinguino = dPin;
    }

    public static int GetDanyoDisparoPinguino()
    {
        return danyoDisparoPinguino;
    }

    public static void SetDanyoDisparoPinguino(int dDisPin)
    {
        danyoDisparoPinguino = dDisPin;
    }



    //Disparos


    public static int GetNumDisparos()
    {
        return numDisparos;
    }

    
    public static void SetNumDisparos(int nDis)
    {
        numDisparos = nDis;
    }

   
    public static int GetMaxNumDisparos()
    {
        return maxNumDisparos;
    }

    public static void SetMaxNumDisparos (int mND)
    {
        maxNumDisparos = mND;
    }
   

    //recarga Disparos
    public static int GetRecargaDisparos()
    {
        return recargaDisparos;
    }

    public static void SetRecargaDispaross(int rD)
    {
        recargaDisparos = rD;
    }


    //Vida

    //Obtener valores maximos y minimos de vida
    public static int GetMinVida()
    {
        return minVida;
    }

    public static int GetMaxVida()
    {
        return maxVida;
    }
     

    //Obtener cantidad de vidas
    public static int GetNumVidas()
    {
        return numVidas;
    }

    //Guardar cantidad de vidas
    public static void SetNumVidas(int nV)
    {
          numVidas = nV;
    }


    //Diamantes

   
    public static int GetNumDiamantes()
    {
        return numDiamantes;
    }
    
    
    public static void SetNumDiamantes(int nDia)
    {
        numDiamantes = nDia;

    }

    //Recarga Diamantes
    public static int GetRecargaDiamantes()
    {
        return recargaDiamantes;
    }

    public static void SetRecargaDiamantes(int rDiam)
    {
        recargaDiamantes = rDiam;
    }

}
