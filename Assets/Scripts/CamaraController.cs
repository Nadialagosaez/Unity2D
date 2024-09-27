using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{

    private GameObject player;
    private void Awake()
    {
        player = (GameObject)GameObject.FindGameObjectWithTag("Player");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        }
    }
}
