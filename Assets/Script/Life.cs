using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float vidaActual;
    public float vidaMaxima;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = 100;
        vidaMaxima = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaActual<=0)
        {
            Destroy(gameObject);
        }
    }
    public void darVidaPorPowerUp()
    {
        vidaActual += 10;
        if (vidaActual>vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }
}
