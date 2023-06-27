using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float maxDistance;
    private Vector3 currentPos;
    private Vector3 initialPos;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*bulletSpeed);
        currentPos = transform.position;
        if (currentPos.magnitude > initialPos.magnitude + maxDistance)
        {   
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Life life = other.GetComponent<Life>();
        //print("No se encontro vida");
        if (life != null)
        {   
            life.vidaActual -= damage;
            //print("Su vida es de "+ life.lifeAmount);
        }
        Destroy(gameObject);
    }

}
