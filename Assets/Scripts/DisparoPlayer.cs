using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Suelo")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Robots")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Murcielagos")
        {
            Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Caparazon")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Pinguino")
        {
            Destroy(this.gameObject);
        }
    }
}
