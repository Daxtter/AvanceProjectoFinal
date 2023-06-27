using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeObjetos : MonoBehaviour
{
    LayerMask mask;
    public   RaycastHit hit;
    GameObject TextDetected;
    GameObject ultimoObjeto = null;
    public float distancia = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Deteccion de raycast");
        
        //TextDetected.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //
      
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, distancia,mask))
        { 
            TextDetected = hit.transform.GetChild(0).gameObject;
            //extDetected.SetActive(false);
            Deselect();
            SelectedObject(hit.transform);
            if(hit.collider.tag == "Objeto" && Input.GetButton("Fire3") )
            {   
                print(hit);
                hit.collider.transform.GetComponent<MaquinaDePerks>().ActivarMasVida();
            }
        }
        else
        {
            Deselect();
        }
    }
    void SelectedObject(Transform transform ) 
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoObjeto = transform.gameObject;
    }
    void Deselect()
    {
        if(ultimoObjeto){
        ultimoObjeto.GetComponent<Renderer>().material.color= Color.white;
        ultimoObjeto = null;
        }
        }
     void OnGUI() {
    if(TextDetected!= null)
    {
    if(ultimoObjeto)
    {
        TextDetected.SetActive(true);
    }
    else{
        
         TextDetected.SetActive(false);
    }
    }    
    }
    
}
