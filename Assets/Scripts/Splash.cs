using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("CambiarEscena", 3.0f);
    }

    private void CambiarEscena()

    {

        SceneManager.LoadScene("02_Menu_ppal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
