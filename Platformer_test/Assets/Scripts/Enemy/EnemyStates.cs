using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    //Basic stuff
    [Header("Properties")]
    [SerializeField] GameObject enemy_chase_trigger;
    [SerializeField] Rigidbody2D enemy_rb2d;
    [SerializeField] float enemy_speed;

    //Chase state
    [Header("Chase State")]
    [SerializeField] Transform target;
    [SerializeField] CircleCollider2D chase_collider;

    //Patrol state
    [Header("Patrol State")]
    [SerializeField] float patrol_duration;
    float timer_patrol;


    //Edge check
    [HideInInspector] public bool isGrounded = false;
    [HideInInspector] public bool isTouchingWall = false;
    [HideInInspector] public bool playerDetected = false;

    //States
    string currentState;
    public void switchState(string state){
        if(state != currentState){
            currentState = state;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = "idle";
    }


    // Update is called once per frame
    void Update()
    {
        if(currentState == "idle"){
            enemy_rb2d.velocity = Vector2.zero;
        }

        if(currentState == "patrol"){
            
        }

        if(currentState == "chase"){
            enemy_rb2d.velocity = new Vector2((target.position.x - gameObject.transform.position.x), 0).normalized * enemy_speed;
        }
    }

}
