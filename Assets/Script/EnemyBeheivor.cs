using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMechanics : MonoBehaviour
{
    public enum EnemyState {Patrol, AttackPlayer};
    public EnemyState currentState;
    [SerializeField]private Sight sightSensor;
    [SerializeField]private float playerAttackDistance;
    //[SerializeField]private Transform [] patrolPoints;
    private UnityEngine.AI.NavMeshAgent agent;
    private int destPoint;
    private GameObject posicionAir;
    

    // Start is called before the first frame update
   // void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.Patrol)
        {
            Patrol();
        }
        else if (currentState == EnemyState.AttackPlayer)
        {
            AttackPlayer();
        }
          
        
        
      
        
    }

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        posicionAir = GameObject.FindGameObjectWithTag("Player");
    }
    private void Patrol()
    {
        /*
        *Si en su patrullaje el enemigo detecta al jugador, el enemigo procedera a perseguir al jugador
        *
        */
        //print("Estas modo patrol");
        agent.isStopped = false;
       // if(!agent.pathPending && agent.remainingDistance < 0.5f)
        //{
            agent.SetDestination ( posicionAir.transform.position);
            //print(posicionAir.transform.position);
       // }
        if(sightSensor.detectedObject !=null )
        {
            currentState = EnemyState.AttackPlayer;
           
        }
        
    }
    private void AttackPlayer()
    {
        agent.isStopped = true;
         print("Estas modo AttackPlayer");
        //Si duarante el atauqe al jugador sale del area de vision del enemigo, el enemigo vuelve a patrullar
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            return;
        }
        //Si el jugador se aljea del enemigo pero aun se encuentra al alcance de la pasersecucion el enemigo lo persiguiera
        float distanceToPlayer = Vector3.Distance(transform.position,sightSensor.detectedObject.transform.position);
        if(distanceToPlayer> playerAttackDistance *1.1f)
        {
            currentState = EnemyState.Patrol;
        }
        FaceTarget(sightSensor.detectedObject.transform.position);
        Shoot();
        //Crear un metodo shot para disparar lento
       
    }
   
     //agent.SetDestination(sightSensor.detectedObject.transform.position);
  
    void FaceTarget(Vector3 targetPosiion)
    {
        Vector3 directionToFace = Vector3.Normalize(
        targetPosiion - transform.position);
        directionToFace.y = 0;
        transform.forward = directionToFace;
    }
    void Shoot()
    {
        EnemyController control = gameObject.GetComponent<EnemyController>();
        
        control.disparar();
        
    }



}
