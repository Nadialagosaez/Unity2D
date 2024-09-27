using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        this.gameObject.transform.Translate(velocidad * Input.GetAxis("Horizontal") * Time.deltaTime, 0.0f, 0.0f);
    }
}
