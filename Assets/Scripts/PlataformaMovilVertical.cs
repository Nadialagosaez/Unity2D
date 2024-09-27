using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilVertical : MonoBehaviour
{

    public float Velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(0.0f, Velocidad * Time.deltaTime, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimiteSup")
        {
            Velocidad = Velocidad * -1;
        }

        if (other.gameObject.tag == "LimiteInf")
        {
            Velocidad = Mathf.Abs(Velocidad);
        }
    }
}
