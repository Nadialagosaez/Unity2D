using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTrampa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
     if(other.gameObject.tag == "Player")
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
