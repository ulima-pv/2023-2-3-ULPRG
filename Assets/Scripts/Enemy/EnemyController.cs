using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour
{
    public IdleState IdleState;
    public FollowState FollowState;

    public  Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 3f;
    public float Speed = 1f;
    public GameObject prefabStone;
    public Transform FirePoint;

    public Rigidbody rb {private set; get;}

    private State currentState;

    private void Awake() 
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();

        // Seteamos el estado inicial
        currentState = IdleState;    
    }

    private void Start() 
    {
        currentState.OnStart();
    }

    private void Update() 
    {
        foreach (var transition in currentState.Transitions)
        {
            if (transition.IsValid())
            {
                // Ejecutar Transicion
                currentState.OnFinish();
                currentState = transition.GetNextState();
                currentState.OnStart();
                break;
            }
        }
        currentState.OnUpdate();    
    }

    public void Fire()
    {
        GameObject stone = Instantiate(prefabStone, FirePoint.position, Quaternion.identity);
        stone.GetComponent<StoneMovement>().Direction =
            Player.position - transform.position;
    }

}
