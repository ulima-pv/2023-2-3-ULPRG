using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour
{
    #region States
    public IdleState IdleState;
    public FollowState FollowState;
    private State currentState;
    #endregion

    #region Parameters
    public  Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 3f;
    public float Speed = 1f;
    public GameObject prefabStone;
    public Transform FirePoint;
    public float CoolDownTime = 1.0f;
    #endregion

    #region Readonly Properties
    public Rigidbody rb {private set; get;}
    public Animator animator {private set; get;}
    #endregion

    

    private void Awake() 
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

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
