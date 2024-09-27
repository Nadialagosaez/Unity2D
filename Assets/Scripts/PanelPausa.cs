using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPausa : MonoBehaviour
{
   public void DetenerJuego()
    {
        Time.timeScale = 0.0f;
    }
}
