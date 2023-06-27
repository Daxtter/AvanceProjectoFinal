using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class CharacterController : MonoBehaviour
{
     public float movementSpeed;
    public float maxSpeed = 10f; 
    private float horizontal;
    private float vertical ; 
    public float jumpForce; 

    //Prefab asociada al proyectil que dispara el jugador
    public GameObject bullet;
    //Punto de referencia para la creación de la bala
    public GameObject bulletSpawner;
    public float sensibilidadDeGiroEnTeclas = 90;
    
public Transform cam; 
public Camera camara;
    private Rigidbody rb;  
    // Start is called before the first frame update
    void Start()
    {
          rb=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Disparo")>0f)
       {
        //Instantiate(bullet,bulletSpawner.transform.position,bulletSpawner.transform.rotation);
        Instantiate(bullet,bulletSpawner.transform.position,bulletSpawner.transform.rotation);
       }  
           bool verdadero = false;
         if(Input.GetKey(KeyCode.K ) || Input.GetAxis("ejeX") >0f) { 
                float anguloK = -sensibilidadDeGiroEnTeclas * Time.deltaTime;
                transform.Rotate(Vector3.up,anguloK);
            }
           if(Input.GetKey(KeyCode.L) || Input.GetAxis("ejeX") <0f)
           {
                float anguloL = sensibilidadDeGiroEnTeclas * Time.deltaTime;
                transform.Rotate(Vector3.up,anguloL);
           }

        Vector3 velocity = Vector3.zero;
        if(horizontal !=0 || vertical != 0)
        {
            Vector3 direction = transform.forward*vertical + transform.right*horizontal;
            velocity = direction * movementSpeed;
        }
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

    }
   
     void FixedUpdate() {
       
    //     //Se asocia el input vertical y/o horizontal hacia una direccion
            //Vector3 direction = new Vector3(horizontal, 0f , vertical);
    //    //Se determina si hay movimiento
         //float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg ;
         //+ cam.eulerAngles.y
         //print(angle);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
           // transform.Rotate(Vector3.up,angle);
       
       
           





    //     if (direction.magnitude > 0){
    //         //Se calcula el angulo del movimiento para rotar la vista del jugador en funcion de la camara.
    //         angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
    //         //transform.rotation = Quaternion.Euler(0f, angle, 0f);
           
    //         Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
    //         if(rb.velocity.magnitude <= maxSpeed)
    //             rb.AddForce(moveDirection * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
           
         }
        
    // }
    // void RotarJugador()
    // {
    //     Vector3 positionOnScreen = camara.WorldToViewportPoint(transform.position);
    //     Vector3 mouseOnScreen = (Vector2) camara.WorldToViewportPoint(Input.mousePosition);
    //     Vector3 direction = mouseOnScreen - positionOnScreen;         
    
    //     float angle  = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg - 90f;
    //     transform.rotation = Quaternion.Euler(new Vector3(0,-angle,0));
    //    rb.MovePosition(rb.position+direction);
    // }
}
