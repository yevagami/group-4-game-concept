using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    //Basic stuff
    [Header("Properties")]
    [SerializeField] Collider2D enemy_chase_trigger;
    [SerializeField] Collider2D enemy_edge_check;
    [SerializeField] Rigidbody2D enemy_rb2d;
    [SerializeField] float enemy_walkSpeed;
    float enemy_speed;


    //Chase state
    [Header("Chase State")]
    [SerializeField] Transform target;
    [SerializeField] float chase_speed;


    //Edge check
    [HideInInspector] public bool isGrounded = false;
    [HideInInspector] public bool isTouchingWall = false;
    [HideInInspector] public bool playerDetected = false;
    [SerializeField] string initialState;
    public int enemy_Dir;

    //States
    public string currentState;
    public void switchState(string state){
        if(state != currentState){
            currentState = state;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        enemy_speed = enemy_walkSpeed;
        currentState = (initialState != "") ? initialState : "patrol";
        if(enemy_edge_check != null) enemy_edge_check.offset = new Vector2(0.81f * enemy_Dir, enemy_edge_check.offset.y);
        if(target == null) target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if(currentState == "idle"){
            enemy_rb2d.velocity = Vector2.zero;
        }

        if(currentState == "patrol"){
            enemy_rb2d.velocity = new Vector2(enemy_Dir * enemy_speed, enemy_rb2d.velocity.y);
        }

        if(currentState == "chase"){
            enemy_speed = chase_speed;
            Vector2 targetDirection = target.position - gameObject.transform.position;
            targetDirection = targetDirection.normalized;
            enemy_rb2d.velocity =  new Vector2(targetDirection.x * enemy_speed, enemy_rb2d.velocity.y);
            if(Mathf.Sign(targetDirection.x) != enemy_Dir){
                flip();
            }
        }

        if((!isGrounded || isTouchingWall) && enemy_edge_check != null){
            flip();
        }
    }

    public void flip(){
        enemy_Dir *= -1;
        if(enemy_edge_check != null) enemy_edge_check.offset = new Vector2(0.81f * enemy_Dir, enemy_edge_check.offset.y);
        Debug.Log("Flip");
    }

}
