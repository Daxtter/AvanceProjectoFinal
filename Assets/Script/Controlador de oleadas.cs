using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//No estoy muy seguro si esta libreria es necesaria, pero pues la voy a dejar
using System.Collections;

public class Controladordeoleadas : MonoBehaviour
{
    public GameObject[] enemigosRestantes;
    [SerializeField]private Transform [] puntosDeAparacion;
    public float oleada;
    public GameObject[] enemigo;
    public float enemigosPorRonda;
    //Variables para esperar cierto tiempo en lo que aparece el otro enemigo
     private float tiempoAEsperar = 1.0f;
    private float timer = 0.0f;
    private float scrollBar = 1.0f;
    int numeroEnemigos=0;

    // Start is called before the first frame update
    void Start()
    {

        oleada = 0;
        //usando enemigos.size nos dara la cantidad de enemigos
        enemigosRestantes=GameObject.FindGameObjectsWithTag("Enemigo");
        enemigosPorRonda = (oleada + 8); 
        Time.timeScale = scrollBar;


    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > tiempoAEsperar)
            { 
                if(enemigosRestantes.Length==0)
                {
                numeroEnemigos = 0;
                print("Entro al if");
                oleada = oleada +1;
                
                //AparicionDeEnemigos();
                }
                if (numeroEnemigos< enemigosPorRonda)
                {
                    AparicionDeEnemigos();
                    numeroEnemigos = numeroEnemigos+1;
                }
                // Remove the recorded 2 seconds.
                timer =0;
                Time.timeScale = scrollBar;
            }
         
            enemigosRestantes=GameObject.FindGameObjectsWithTag("Enemigo");
    }   

    
    void AparicionDeEnemigos()
    {
        //print("Enemigo creado");
        int posicion =Random.Range(0,puntosDeAparacion.Length);
        Instantiate(enemigo[0],puntosDeAparacion[posicion].transform.position,puntosDeAparacion[posicion].transform.rotation);
            
    }
}
